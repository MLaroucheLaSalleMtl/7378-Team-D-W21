using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCharacter : MonoBehaviour
{
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position != null)
        {
            Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
