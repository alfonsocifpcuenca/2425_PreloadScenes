using System.Collections;
using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField] private int totalSeconds = 10;

    void Awake()
    {
        // Simula una carga costosa bloqueando el hilo (NO recomendado en producción)
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - start < 5f)
        {
            // Opcional: haz trabajo pesado falso
            double dummy = 0;
            for (int i = 0; i < 10000; i++)
            {
                dummy += Mathf.Sqrt(i) * Mathf.Sin(i);
            }
        }

        Debug.Log("Carga simulada completada");
    }

    private IEnumerator TrueHeavyWork()
    {
        for (int second = 1; second <= totalSeconds; second++)
        {
            Debug.Log($"Segundo {second}/{totalSeconds}");

            // Trabajo pesado REAL distribuido en frames
            yield return StartCoroutine(DoHeavyWorkForOneSecond());
        }

        Debug.Log("Trabajo completado");
    }

    private IEnumerator DoHeavyWorkForOneSecond()
    {
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup - startTime < 1f)
        {
            // Trabajo computacional intensivo
            for (int i = 0; i < 100000; i++)
            {
                Vector3 v = new Vector3(
                    Mathf.Sin(i * 0.1f),
                    Mathf.Cos(i * 0.1f),
                    Mathf.Sqrt(i)
                );
                float magnitude = v.magnitude;
            }

            yield return null; // Permitir que Unity actualice
        }
    }
}
