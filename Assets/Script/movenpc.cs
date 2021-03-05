using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movenpc : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * speed);
        if (transform.position.x > -6f)
        {
            speed = -speed;
        }
        else if (transform.position.x < -10f)
        {
            speed = -speed;

        }
    }
}
