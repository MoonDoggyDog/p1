using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInHand : MonoBehaviour
{
    public GameObject currentPlayer;

    private GameManager managerScript;

    public ShootingManager shootingManagerScript;
    private PScript playerScript;

    public bool isColide;

    private void Start()
    {
        managerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void Update()
    {
        currentPlayer = managerScript.currentPlayerGameObj;

        playerScript = currentPlayer.GetComponent<PScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        //Debug.Log("колайд");
        if(collision.gameObject.CompareTag("Baricade"))
        {
            isColide = true;
            playerScript.canShoot = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //Debug.Log("-колайд");
        if (collision.gameObject.CompareTag("Baricade"))
        {
            isColide = false;
            playerScript.canShoot = true;
        }
    }
}
