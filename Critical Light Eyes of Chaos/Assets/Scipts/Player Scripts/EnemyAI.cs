using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public float damage;
    public Player players;

    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange,playerInAttackingRange;

    public void Awake()
    {
        player = GameObject.Find("Character").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackingRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackingRange) patrolling();
        if (playerInSightRange && !playerInAttackingRange) ChasePlayer();
        if (playerInSightRange && playerInAttackingRange) AttackPlayer();

        
    }

    private void patrolling()
    {
        if (!walkPointSet) searchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distancToWalkPoint = transform.position - walkPoint;

        if (distancToWalkPoint.magnitude <1f)
            walkPointSet = false;
    }
    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(-walkPoint, transform.up, 2f, whatIsGround))
            walkPointSet = true;   
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -32f, ForceMode.Impulse);
            rb.AddForce(transform.up * -8f, ForceMode.Impulse);
            rb.rotation = transform.rotation;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
           
        }
    }
    
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void resetAttack()
    {
        alreadyAttacked = false;
    }
}
