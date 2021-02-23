using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject[] enemys;
    int rdm;
    Vector2 spawnSpace;
    public float spawnCooldown = 2f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnCooldown;
            rdm = Random.Range(0,enemys.Length);
            spawnSpace = new Vector2(transform.position.x, transform.position.y);
            Instantiate(enemys[rdm], spawnSpace, Quaternion.identity);
        }
    }
}
