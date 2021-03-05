using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{

    public int damage;

    private Animator anime;
    private BoxCollider2D colli2D;

    // Start is called before the first frame update
    void Start()
    {
        anime = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        colli2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            colli2D.enabled = true;
            anime.SetTrigger("Attack");
        }
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Knight>().TakeDamage(damage);
        }

    }


}
