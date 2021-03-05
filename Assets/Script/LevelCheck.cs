using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCheck();
    }

    void EnemyCheck()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            door.SetActive(false);
        }
        
    }
}
