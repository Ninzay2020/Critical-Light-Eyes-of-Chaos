using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimAnimation : MonoBehaviour
{
    public Animator animator; 
    public Player player;
    public HealthComponent health;
    public GameObject Magmacrest;
    public GameObject RAH;
    [SerializeField] private Transform castPoint;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Idle();
        InvokeRepeating("UltimateAttack", 100,100);
        InvokeRepeating("Roar", 15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        player.inDanger = true;
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorTransitionInfo transitionInfo = animator.GetAnimatorTransitionInfo(0);
        
        if (health.currentHealth <= 0)
        {
            health.currentHealth = 0;
            Invoke("Defeat", 0);
            animator.SetBool("isUltReady?", false);
        }
       
       if(stateInfo.IsName("DEAD"))
        {
            Destroy(this.gameObject);
        }
       
        if(stateInfo.IsName("Spawnwave") && animator.GetBool("isUltReady?") == true)
        {
            print("DIEwwaw!");
            Instantiate(this.Magmacrest, castPoint.position, castPoint.rotation);
            animator.SetBool("isUltReady?", false);
        }

        if(stateInfo.IsName("Roar") && animator.GetBool("isRoar") == true)
        {
            RAH.SetActive(true);
            player.inDanger = true;
            player.dangerTime = 5f;
            player.transform.Translate(Vector3.back * 5.0f * Time.deltaTime);
            Invoke("Idle", 4);
            
        }
    }

    void UltimateAttack()
    {
        if (player.currentHealth > 0 && health.currentHealth > 0)
        {
            print("DIE!");
            //Instantiate(this.Magmacrest, castPoint.position, castPoint.rotation);
            animator.SetBool("isUltReady?", true);
            
            Invoke("Idle", 5);
        }
    }

    void Idle()
    {
        animator.SetBool("isUltReady?", false);
        animator.SetBool("isRoar", false);
        animator.SetBool("inStomp", false);
        animator.SetBool("canSlam", false);
        RAH.SetActive(false);
        
    }

    void Defeat()
    {
        animator.SetBool("isDead", true);
    }

    void Roar()
    {
        animator.SetBool("isRoar", true);
        player.inDanger = true;
        player.dangerTime = 5f;
    }
}
