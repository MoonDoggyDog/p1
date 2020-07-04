using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    private P1Shooting readytoshootscript;

    public bool isColide;
    private void Start()
    {
         readytoshootscript = GameObject.Find("Player1").GetComponent<P1Shooting>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Baricade"))
        {
            isColide = true;
            readytoshootscript.canShoot = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Baricade"))
        {
            isColide = false;
            readytoshootscript.canShoot = true;
        }
    }
}
