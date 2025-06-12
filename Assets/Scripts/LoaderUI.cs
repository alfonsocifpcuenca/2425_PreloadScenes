using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoaderUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider loadingSlider;
    public Text loadingText;
    public GameObject loadingScreen;

    [Header("Scene Configuration")]
    public string sceneToLoad;

    public void SetPercentage(float percentage)
    {
        this.loadingSlider.value = percentage;
        int percentageInt = Mathf.RoundToInt(percentage * 100);
        this.loadingText.text = $"Cargando: {percentageInt}%";
    }
}
