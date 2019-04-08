using UnityEngine;
using System.Collections;

//Author: Unity Tutorial
//Modified By: Adriana Arzola
//Date: 04/07/2019
public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        //stop movement if enemy is dead
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
