using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anime; 
    public float walkSpeed;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void Movement()
    {
        float hmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        
        //character move
        if (hmove != 0)
        {
            rb.velocity = new Vector2(hmove * walkSpeed ,rb.velocity.y);
        //character move with animation
            anime.SetFloat("running", Mathf.Abs(facedirection));
        }
        if(facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
       

   
    }
    
 
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
}
