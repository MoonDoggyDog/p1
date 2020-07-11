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

    public Vector3 rayOffset;
    public Vector3 rayOriginOffset ;

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

    public void PlayerInViev(Transform player)
    {
        RaycastHit raycastHit;

        Ray ray = new Ray (transform.position + rayOriginOffset, player.transform.position - rayOffset);

        if (Physics.Raycast(ray, out raycastHit, 2))
        {
            Debug.Log(raycastHit.transform.name);
        }

        Debug.DrawRay(transform.position + rayOriginOffset, player.transform.position - rayOffset);
    }
}
