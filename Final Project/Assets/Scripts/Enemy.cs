using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;
    float startingX;
    int dir = 1;
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
            dir *= -1;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

}