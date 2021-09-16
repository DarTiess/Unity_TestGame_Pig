using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject dogPrefab;
    public Vector3[] startPoints = new[] {
        new Vector3(0, 0, 0),
        new Vector3(0,0, 0),
        new Vector3(0, 0, 14),
        new Vector3(0, 6, 6),
      
    };
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeDog", 1f, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeDog()
    {
        int rnd = Random.Range(0, startPoints.Length);
        Instantiate(dogPrefab, startPoints[rnd], dogPrefab.transform.rotation);
    }
}
