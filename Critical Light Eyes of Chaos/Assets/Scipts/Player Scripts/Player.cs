using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public float maxHealth;
	public float currentHealth;
	public int regeneration = 5;
	public HealthBar healthBar;
    public bool inDanger;
	public InDanger danger;
	public float dangerTime = 30.0f;
	public InventoryManager inventoryManager;
	public GameObject defeat;

	
	

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		defeat.gameObject.SetActive(false);

    }

    private void Awake()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth >= maxHealth)
        {
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }
        if (inDanger)
        {
            danger.gameObject.SetActive(true);
            dangerTime -= Time.deltaTime;
        }
        if (dangerTime <= 0.0f)
		{
			timerEnded();
			
		}
		
		healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
			defeat.gameObject.SetActive(true);
            
        }

		if (!inDanger && currentHealth < maxHealth)
		{
			Invoke("Regenerate", 0);
			Regenerate();
        }

    }

	void TakeDamage(int damage)
	{
		if (currentHealth > 0)
		{
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }

		if (currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
		

		
	}

    public void Regenerate()
    {
			if (currentHealth < maxHealth)
			{
				currentHealth+= 0.01f;
				healthBar.SetHealth(currentHealth);
			}
		
		if (currentHealth >= maxHealth)
		{
			currentHealth = 100;
			healthBar.SetHealth(currentHealth);
		}

       
    }
	void timerEnded()
	{
        inDanger = false;
        danger.gameObject.SetActive(false);
		dangerTime = 30.0f;
		
    }
}
