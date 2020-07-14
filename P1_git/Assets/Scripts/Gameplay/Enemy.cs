using System.Collections;
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
    public bool moveToPlayer;

    public Animation bazookaShot;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();


        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveToPlayer)
        {
            Movement("MoveToPlayer");
        }

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
            if (raycastHit.transform.name == "Player1" | raycastHit.transform.name == "Player2" )
            {
               // Debug.Log(raycastHit.distance);
                if ( raycastHit.distance < 15 /*&& raycastHit.distance > 3*/)
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

    IEnumerator Shoot()
    {
        Debug.Log("BUM");
        //bazooka.
        enemyReadyToShot = false;
        //bazooka.GetComponent<Rigidbody>().AddForce(-transform.forward * bazookaForse, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        enemyReadyToShot = true;
    }
}
