using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject prefab;
    public float delay = 1;
    float timer; 

    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
        // Grab all
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<= 0)
        {
            var position = new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y,0);
            Destroy(Instantiate(prefab, position, Quaternion.identity),3);
            timer = delay;
        }
    }
}