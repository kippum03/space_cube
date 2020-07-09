using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xRange = 15;
    private float ySpawnPos = 140;
    private float zRange = 15;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 10)
        {
            Destroy(gameObject);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, Random.Range(-zRange, zRange));
    }
}
