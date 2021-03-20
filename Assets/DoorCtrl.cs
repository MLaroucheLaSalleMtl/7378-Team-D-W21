using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    public string scenceName = "";
    private bool canMove = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = true;
            CharacterControl cc;
            GameObject playerGo;
            playerGo = GameObject.FindGameObjectWithTag("Player");

            cc = playerGo.GetComponent<CharacterControl>();
            if (canMove)
            {
                cc.enabled = false;
            }
            StartCoroutine(waitForScence());
        }
    }

    IEnumerator waitForScence()
    {
        yield return new WaitForSeconds(5f);
        
        Application.LoadLevel(scenceName);
    }

    
}

