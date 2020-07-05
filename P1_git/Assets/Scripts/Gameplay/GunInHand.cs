using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInHand : MonoBehaviour
{
    public ShootingManager shootingManagerScript;

    public bool isColide;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Baricade"))
        {
            isColide = true;
            shootingManagerScript.canShoot = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Baricade"))
        {
            isColide = false;
            shootingManagerScript.canShoot = true;
        }
    }
}
