using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public float MaxHealth;
    public float currentHealth;
    public float damage;
    public string enemyType;

    public Player player;
    //public Spell spell;
    private void Awake()
    {
        currentHealth = MaxHealth; 
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            if (this.gameObject.tag == ("Enemy"))
            {
                Destroy(this.gameObject);
            }

        }
    }

    public void TakeDamage(float damageToApply)
    {
      
        currentHealth -= damageToApply;
        Debug.Log("Enemy Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            if (this.gameObject.tag == ("Enemy"))
            {
                Destroy(this.gameObject);
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemyType != "Boss")
        {
            player.currentHealth -= damage;
            player.inDanger = true;
            player.dangerTime = 20f;
        }
        if (enemyType == "Boss")
        {
            player.currentHealth -= damage;
            player.dangerTime = 120f;
            player.inDanger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enemyType != "Boss")
        {
            player.currentHealth -= damage;
            player.inDanger = true;
            player.dangerTime = 30f;
        
    }
        if (enemyType == "Boss")
        {
            player.currentHealth -= damage;
            player.dangerTime = 120f;
            player.inDanger = false;
        }
    }
}
