using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float zombieMaxHealth, zombieHealth, zombieDamage, attackCooldown;
    NavMeshAgent navMeshAgent;
    Rigidbody rb;
    Animator animator;

    PlayerStats player;
    Transform playerTransform;

    float thresholdChange = 1.0f;
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
}
