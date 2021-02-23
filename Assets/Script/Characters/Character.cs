using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject character;
    public GameObject attackP;
    public Animator animator;
    private Rigidbody2D characterRB;
    private SpriteRenderer characterSR;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    public string characterName;
    public int maxHealth;
    public int health;
    public int attackDamage;
    public float moveSpeed;
    public bool fly;
    public bool jump;
    public float hoverHight;
    public float attackSpeed;

    private bool flipCheck = false;

    private float attackCooldown = 0f;

    private float healthPercent;
    private float movement;

    public Character(string characterName, int health, int attackDamage, float moveSpeed, bool fly, bool jump, float hoverHight)
    {
        this.characterName = characterName;
        this.health = health;
        this.attackDamage = attackDamage;
        this.moveSpeed = moveSpeed;
        this.fly = fly;
        this.jump = jump;
        this.hoverHight = hoverHight;
    }

    private void Start()
    {
        characterRB = GetComponent<Rigidbody2D>();
        characterSR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        Turn(movement);
        MoveAnim();
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;
        Hover();

        if (Time.time >= attackCooldown)
        {
            AttackAnim();
        }
    }

    private void MoveAnim()
    {
        if (!fly)
        {
            if (movement != 0)
            {
                animator.SetBool("Move", true);
            }
            else if (movement == 0)
            {
                animator.SetBool("Move", false);
            }
        }
    }

    private void Turn(float a)
    {
        if (a >0)
        {
            characterSR.flipX = false;
        }
        else if (a<0)
        {
            characterSR.flipX = true;
        }
        AttackPointTrun();
    }

    private void AttackPointTrun()
    {
        if (flipCheck != characterSR.flipX)
        {
            attackP.transform.localPosition = new Vector3(-attackP.transform.localPosition.x, attackP.transform.localPosition.y);
            flipCheck = characterSR.flipX;
        }
    }

    private void Hover()
    {
        if (fly)
        {
            Fly();
        }
        else if (jump)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(characterRB.velocity.y) < 0.001f)
        {
            characterRB.AddForce(new Vector2(0, hoverHight), ForceMode2D.Impulse);
        }
    }

    private void Fly()
    {
        if (Input.GetButtonDown("Jump"))
        {
            characterRB.AddForce(new Vector2(0, hoverHight), ForceMode2D.Impulse);
        }
    }
    
    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AttackAnim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
            Attack();
            attackCooldown = Time.time + 1f / attackSpeed;
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Attack", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

        animator.SetTrigger("GetHit");

        HP();


    }

    private void Die()
    {
        animator.SetBool("IsDead", true);
    }

    private void AfterDeath()
    {
        Destroy(character.gameObject);
    }

    public void HP()
    {
        healthPercent = (float)health / maxHealth;
        if (healthPercent >= 0)
        {
            healthBar.transform.localScale = new Vector3(healthPercent, healthBar.transform.localScale.y);
        }
        else
        {
            healthBar.transform.localScale = new Vector3(0, healthBar.transform.localScale.y);
        }
    }
}
