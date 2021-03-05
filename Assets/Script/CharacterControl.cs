using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anime;
    private CapsuleCollider2D tGround;
    private bool isGround;

    public float walkSpeed;
    public float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        tGround = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        Movement();
        Jump();
        TouchGround();
       // Attack();
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

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                rb.velocity = Vector2.up * jumpVel;
            }
        }
    }

    //void Attack()
    //{
    //    if (Input.GetButtonDown("Attack"))
    //    {
    //        anime.SetTrigger("Attack");
    //    }
    //}

   

    void TouchGround()
    {
        isGround = tGround.IsTouchingLayers(LayerMask.GetMask("Ground"));
        //Debug.Log(isGround);
    }

 
    // Update is called once per frame
    
}
