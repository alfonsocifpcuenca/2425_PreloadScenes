using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private GameObject loaderUI;
    [SerializeField] private string sceneToLoad;

    public void OnMouseDown()
    {
        StartCoroutine(LoadSceneAsync(this.sceneToLoad));
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        // Activar pantalla de carga
        var loadingScreen = Instantiate(this.loaderUI, Vector3.zero, Quaternion.identity);
        loadingScreen.SetActive(true);

        // Obtener el script que maneja el loader
        var loaderScript = loadingScreen.GetComponent<LoaderUI>();

        Debug.Log($"Comenzando carga de {sceneName}");

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            Debug.Log($"[CARGA] {asyncLoad.progress * 100f}%");

            if (loaderScript != null)
                loaderScript.SetPercentage(asyncLoad.progress);

            yield return null;
        }

        if (loaderScript != null)
            loaderScript.SetPercentage(1f);

        Debug.Log($"[CARGA] 100%");
        Debug.Log($"[CARGA] Esparamos 1 segundo para entrar en la nueva escena");
        yield return new WaitForSeconds(1f);

        asyncLoad.allowSceneActivation = true;
    }
}
