using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nextLevel;
    Vector2 spawnSpace;
    public static GameManager instance = null;
    [SerializeField] public GameObject spawnPoint;
    [SerializeField] private GameObject playerPawn;
 
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if(instance!=null)
        {
            Destroy(gameObject);
        }
    
    }
    // Start is called before the first frame update
    void Start()
    {
        if (playerPawn == null)
        {
            playerPawn = GameObject.FindGameObjectWithTag("Player");
        }
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
            playerPawn.transform.position = spawnPoint.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPawn == null)
        {
            playerPawn = GameObject.FindGameObjectWithTag("Player");
        }
        if (spawnPoint == null) 
        {
            spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
            playerPawn.transform.position = spawnPoint.transform.position;
        }
    }
    public void next()
    {
        Destroy(GameObject.FindGameObjectWithTag("Map"));
        Instantiate(nextLevel, spawnSpace, Quaternion.identity);
        //playerPawn.transform.position = spawnPoint.transform.position;
    }
}
