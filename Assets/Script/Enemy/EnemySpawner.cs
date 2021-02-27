using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject enemySpawner;
    public int count;

    public GameObject[] enemys;
    int rdm;
    Vector2 spawnSpace;

    public float spawnCooldown = 2f;
    //private float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            rdm = Random.Range(0, enemys.Length);
            spawnSpace = new Vector2(transform.position.x, transform.position.y);
            GameObject enemy = Instantiate(enemys[rdm], spawnSpace, Quaternion.identity);
            enemy.transform.parent = enemySpawner.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time > nextSpawn)
        //{
        //    nextSpawn = Time.time + spawnCooldown;
        //    rdm = Random.Range(0,enemys.Length);
        //    spawnSpace = new Vector2(transform.position.x, transform.position.y);
        //    Instantiate(enemys[rdm], spawnSpace, Quaternion.identity);
        //}
    }
}
