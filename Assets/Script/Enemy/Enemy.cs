using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject enemy;
    public Animator animator;
    private Rigidbody2D enemyRB;
    private SpriteRenderer enemySR;

    public TextMesh damageText;
    public GameObject damageGO;

    public string enemyName;
    public int maxHealth;
    public int health;
    public int attackDamage;
    public float moveSpeed;
    public bool hunt;
    public bool fly;
    public bool jump;
    public float hoverHight;

    private float healthPercent;
    private float movement;

    public GameObject attackP;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayers;
    public float attackSpeed;
   
   // private float attackCooldown = 0f;

    //partsystem
    public GameObject blood;
    protected AudioSource deathAudio;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        ShowDamage(damage);

        if (health <= 0)
        {
            Die();
        }

        animator.SetTrigger("GetHit");
        
      GameObject b= GameObject.Instantiate(blood, this.transform.position, Quaternion.identity);
      
        HP();

    }

    private void Die()
    {
        animator.SetBool("IsDead",true);
        deathAudio = GetComponent<AudioSource>();
    }

    private void AfterDeath()
    {
        deathAudio.Play();
        Destroy(enemy.gameObject);
    }

    public void HP()
    {
        healthPercent = (float)health/ maxHealth;
        //Debug.Log(healthPercent);
        if (healthPercent >= 0)
        {
            healthBar.transform.localScale = new Vector3(healthPercent, healthBar.transform.localScale.y);
            Attack();
        }
        else
        {
            healthBar.transform.localScale = new Vector3(0, healthBar.transform.localScale.y);
        }
    }

    private void Attack()
    {
        animator.SetBool("Attack", true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != null)
            {
                enemy.GetComponent<Character>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void ShowDamage(int damage)
    {
        damageText.text = damage.ToString();
        GameObject a = Instantiate(damageGO, transform.position, Quaternion.identity);
        a.transform.parent = enemy.transform;
    }
}
