using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : MonoBehaviour
{
    public Animator animator;
    public JimAnimation jim;
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
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("inStomp", true);
            jim.Invoke("Idle", 7);
        }
    }

    

}
