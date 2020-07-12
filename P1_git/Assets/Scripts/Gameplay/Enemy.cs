using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    private Transform player;

    private NavMeshAgent navMeshAgent;

    public Vector3 rayOffset;
    public Vector3 rayOriginOffset;

    public float meleeAtackRange;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();


        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        player = gameManager.currentPlayerGameObj.transform;
    }

    private void Movement(string whatToDo)
    {
        if (whatToDo == "MoveToPlayer")
        {
            navMeshAgent.destination = player.position;
        }
        else if(whatToDo == "moveToPathPoint")
        {

        }
    }

    public void PlayerInViev(Transform player)
    {
        RaycastHit raycastHit;

        Ray ray = new Ray (transform.position, player.transform.position - transform.position );

        if (Physics.Raycast(ray, out raycastHit))
        {
            //Debug.Log(raycastHit.transform.name);
            if (raycastHit.transform.name == "Player1")
            {
                //Debug.Log(player.transform.position);
                if (raycastHit.distance < 15)
                {
                    Movement("MoveToPlayer");
                }
                else if (raycastHit.distance >= 15)
                {
                    Shoot();
                }
            }
        }

        Debug.DrawRay(transform.position, player.transform.position - transform.position);
    }

    public void Shoot()
    {

    }
}
