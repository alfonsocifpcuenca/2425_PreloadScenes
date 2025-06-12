using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public int amount = 5000;

    private void Awake()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-50f, 50f),
                Random.Range(-50f, 50f),
                Random.Range(-50f, 50f));
            Instantiate(prefabToSpawn, position, Quaternion.identity);
        }

        Debug.Log($"Instanciados {amount} objetos pesados en Awake.");
    }
}
