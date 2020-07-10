using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    private Transform player;

    private NavMeshAgent navMeshAgent;

    public bool moveToPlayer = false;

    public bool moveToPathPoint = true;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();


        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        player = gameManager.currentPlayerGameObj.transform;

        Movement();
    }

    private void Movement()
    {
        if (moveToPlayer)
        {
            navMeshAgent.destination = player.position;
        }
        else if(moveToPathPoint)
        {

        }
    }
}
