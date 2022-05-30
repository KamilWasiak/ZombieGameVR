using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float zombieMaxHealth, zombieDamage, attackCooldown;
    public float zombieHealth;
    NavMeshAgent navMeshAgent;
    Rigidbody rb;
    Animator animator;

    PlayerStats player;
    Transform playerTransform;

    float thresholdChange = 0.5f;
    private Vector3 lastTransformPos;

    private bool attackEnabled;
    

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        lastTransformPos = transform.position;

        zombieHealth = zombieMaxHealth;
        attackEnabled = true;
    }

    private void Update()
    {
        HandleZombieMovement();
        ZombieDeath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHitbox")
        {
            ZombieAttack();
        }
    }

    private void HandleZombieMovement()
    {
        navMeshAgent.SetDestination(playerTransform.position);

        var diffVector = transform.position - lastTransformPos;
        if (diffVector.magnitude >= thresholdChange)
        {
            lastTransformPos = transform.position;
            animator.SetTrigger("Walking");
        }

        else
        {
           //animator.SetBool("IsWalking", false);
        }
    }


    private void ZombieAttack()
    {
        if (attackEnabled == true)
        {
            animator.SetTrigger("Attacking");
            player.playerHealth -= zombieDamage;
            attackEnabled = false;
            StartCoroutine(AttackCooldown(attackCooldown));
        }
    }

    private IEnumerator AttackCooldown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        attackEnabled = true;
    }

    private void ZombieDeath()
    {
        if (zombieHealth <= 0)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Dead");
            StartCoroutine(DestroyZombie(50.0f));
        }
    }

    private IEnumerator DestroyZombie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
