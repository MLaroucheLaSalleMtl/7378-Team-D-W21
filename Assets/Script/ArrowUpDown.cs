using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUpDown : MonoBehaviour
{
    public float speed = 10f;

    public bool isUp = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            transform.Translate(this.transform.up * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(-this.transform.up * Time.deltaTime * speed);
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
