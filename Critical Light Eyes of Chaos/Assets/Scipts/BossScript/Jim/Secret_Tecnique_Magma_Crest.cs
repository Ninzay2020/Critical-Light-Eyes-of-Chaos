using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Tecnique_Magma_Crest : MonoBehaviour
{
    public float speed = 0f;
    public Player character;

    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<Player>();
        Invoke("Destruction", 5);

    }
    private void Awake()
    {
   
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            character.currentHealth -= character.maxHealth;
        }
    }

    private void Destruction()
    {
        Destroy(this.gameObject);
    }
}
