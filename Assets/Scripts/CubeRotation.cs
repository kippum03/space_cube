using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeRotation : MonoBehaviour
{
    public int RandomVector = 0;
    public float SpinSpeed = 0;
    private int repeatRate = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomizeCubeVector", 2, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomVector == 1) { transform.Rotate(new Vector3(Time.deltaTime * SpinSpeed, Time.deltaTime * 5, Time.deltaTime * 3)); }
        else if (RandomVector == 2) { transform.Rotate(new Vector3(Time.deltaTime * 3, Time.deltaTime * SpinSpeed, Time.deltaTime * 5)); }
        else if (RandomVector == 3) { transform.Rotate(new Vector3(Time.deltaTime * 5, Time.deltaTime * 3, Time.deltaTime * SpinSpeed)); }
    }
    void RandomizeCubeVector()
    {
        SpinSpeed = Random.Range(20, 30);
        RandomVector = Random.Range(1, 4);
        repeatRate = Random.Range(4, 7);
    }
}
