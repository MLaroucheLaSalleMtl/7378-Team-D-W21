using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    public bool isRight = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            transform.Translate(this.transform.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(-this.transform.right * Time.deltaTime * speed);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<Character>().TakeDamage(10);
            Destroy(this.gameObject, 0f);
        }
    }
}
