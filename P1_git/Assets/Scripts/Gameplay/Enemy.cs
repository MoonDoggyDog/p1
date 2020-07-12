﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject sword;
    public GameObject bazooka;

    private GameManager gameManager;

    private Transform player;

    private NavMeshAgent navMeshAgent;

    public Vector3 rayOffset;
    public Vector3 rayOriginOffset;

    public float meleeAtackRange;
    public float bazookaForse;

    public bool enemyReadyToShot;

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
                Debug.Log(raycastHit.distance);
                if (raycastHit.distance < 15)
                {
                    sword.SetActive(true);
                    Movement("MoveToPlayer");
                }
                else if (raycastHit.distance >= 15 && enemyReadyToShot)
                {
                    StartCoroutine(Shoot());
                }
            }
        }

        Debug.DrawRay(transform.position, player.transform.position - transform.position);
    }

    /*public void Shoot()
    {
        bazooka.GetComponent<Rigidbody>().AddForce(-transform.forward * bazookaForse, ForceMode.Impulse);
    }*/

    IEnumerator Shoot()
    {
        Debug.Log("sus");
        enemyReadyToShot = false;
        bazooka.GetComponent<Rigidbody>().AddForce(-transform.forward * bazookaForse, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        enemyReadyToShot = true;
    }
}
