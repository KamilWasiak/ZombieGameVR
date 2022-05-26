using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class ZombieAI : MonoBehaviour
{
    public NavMeshAgent enemy;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
