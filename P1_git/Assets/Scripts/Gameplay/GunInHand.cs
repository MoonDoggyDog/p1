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


        currentPlayer = managerScript.currentPlayerGameObj;

        playerScript = currentPlayer.GetComponent<PScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Baricade"))
        {
            isColide = true;
            playerScript.canShoot = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Baricade"))
        {
            isColide = false;
            playerScript.canShoot = true;
        }
    }
}
