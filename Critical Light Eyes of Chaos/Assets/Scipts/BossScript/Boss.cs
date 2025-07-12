using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public int regeneration = 5;
    public HealthBar healthBar;
    public bool inDanger;
    public float dangerTime = 30.0f;
    public GameObject Victory;
 
    public HealthComponent healthComponent;




    // Start is called before the first frame update
    void Start()
    {
        
        maxHealth = healthComponent.MaxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


    }

    private void Awake()
    {

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = healthComponent.currentHealth;
        if (currentHealth >= maxHealth)
        {
            currentHealth = healthComponent.MaxHealth;
            healthBar.SetHealth(currentHealth);
        }

        healthBar.SetHealth(currentHealth);
        if (currentHealth > 0)
        {

            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Victory.SetActive(true);
        }

    }

}

   