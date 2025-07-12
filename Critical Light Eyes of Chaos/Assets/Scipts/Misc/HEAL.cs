using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEAL : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.currentHealth = player.maxHealth;
            player.inDanger = false;
        }
    }
}
