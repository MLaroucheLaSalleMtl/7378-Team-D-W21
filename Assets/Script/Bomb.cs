using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator anim;
    protected AudioSource bombAudio;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        bombAudio = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("Boom");
            other.GetComponent<Character>().TakeDamage(50);
            bombAudio.Play();
            Destroy(this.gameObject, 0.8f);
        }
    }
}
