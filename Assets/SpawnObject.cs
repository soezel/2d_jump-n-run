using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;
  
    void Start()
    {
        InvokeRepeating("SpawnObj", 2, 2);
    }

    Vector2 GetSpawnPoint()
    {
        float x = Random.Range(-8.5f, -2.5f);
        float y = Random.Range(-3.5f, -3.5f);

        return new Vector2(x, y);
    }

    void SpawnObj()
    {
        Instantiate(objectToSpawn, GetSpawnPoint(), Quaternion.identity);
    }
}