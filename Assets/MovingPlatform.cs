using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingType
{
    up,
    left,
}

public class MovingPlatform : MonoBehaviour
{

    public MovingType type = MovingType.left;

    // Start is called before the first frame update
   
    private float radian;
    public float moveAmplitude = 5f;
    private Vector3 oldPos;

    private Transform player;

    void Start()
    {
        oldPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        radian += Time.deltaTime;
        float newY = Mathf.Cos(radian) * moveAmplitude;
        if(type==MovingType.up)
        {
            transform.position = oldPos + Vector3.up * newY;
        }else
        {
            transform.position = oldPos + Vector3.right * newY;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnCollisionExitr2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = player.transform;
        }
    }
}
