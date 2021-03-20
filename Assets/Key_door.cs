using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_door : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
