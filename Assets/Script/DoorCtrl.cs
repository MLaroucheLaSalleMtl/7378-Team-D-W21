using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    public Transform otherPoint;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = new Vector3(otherPoint.position.x, otherPoint.position.y, otherPoint.position.z);
        }
    }

}

