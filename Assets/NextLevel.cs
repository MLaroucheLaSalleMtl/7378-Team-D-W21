using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    //public GameObject nextLevel;
    //Vector2 spawnSpace;
    // Start is called before the first frame update

    private GameManager code;
    void Start()
    {
        code = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void next()
    //{
    //    Destroy(GameObject.FindGameObjectWithTag("Map"));
    //    Instantiate(nextLevel, spawnSpace, Quaternion.identity);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("next");
            code.next();
        }
    }
}
