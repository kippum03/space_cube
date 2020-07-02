using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSphere());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnSphere()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    
    }
}
