using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatArrow : MonoBehaviour
{
    public GameObject arrow;

    public float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("creatArrow", 0f, timer);
    }

   public void creatArrow()
    {
        GameObject go = GameObject.Instantiate(arrow, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(go.gameObject, 10f);

    }
}
