using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PScript : MonoBehaviour
{

    public ShootingManager shootingManager;

    public Quaternion hitRotation;

    public GameObject FirePoint, GameManagerScriptTo, bulletPrefab, currentPlayer;

    private GameObject laserInHand, pistolInHand, circleInHand, rocketInHand;
    public GameObject[] gunsInHand = new GameObject[4];

    public bool[] readyToShoot;
    bool laserReadyToShoot = false, pistolReadyToShoot = false, circleReadyToShoot = false, rocketReadyToShoot = false;
    public bool canShoot = true, lasCanShoot = true;

    private bool laserGun, pistolGun, circleGun, rocketGun;
    public bool[] guns;

    public float laserOverLoadCD, laserpartOf, laserCurrentDamageDeal, pistolShootCd;
    public float pistolShootForse = 100;

    private void Update()
    {
    }

    private void Start()
    {
        
        shootingManager = FindObjectOfType<ShootingManager>().GetComponent<ShootingManager>();

        //gunsInHand = new GameObject[4] /*{ laserInHand, pistolInHand, circleInHand, rocketInHand}*/;

        guns = new bool[4] { laserGun = false, pistolGun = false, circleGun = false, rocketGun = false };
        for (int i = 0; i < guns.Length; i++) { guns[i] = false; }

        readyToShoot = new bool[4] { laserReadyToShoot, pistolReadyToShoot, circleReadyToShoot, rocketReadyToShoot };
        for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("kek");
        if (other.CompareTag("laser"))
        //if (other.name == "laserGo")
        {
            //Debug.Log("keklaser");
            //Debug.Log(guns.Length);
            for (int i = 0; i < guns.Length; i++) { guns[i] = false; }
            for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }
            for (int i = 0; i < gunsInHand.Length; i++) { gunsInHand[i].SetActive(false); }
            guns[0] = true;
            readyToShoot[0] = true;
            Destroy(other.gameObject);
            gunsInHand[0].SetActive(true);
        }

        if (other.gameObject.CompareTag("pistol"))
        //if (other.name == "pistolGo")
        {
            //Debug.Log("kekois");
            for (int i = 0; i < guns.Length; i++) { guns[i] = false; }
            for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }
            for (int i = 0; i < gunsInHand.Length; i++) { gunsInHand[i].SetActive(false); }
            guns[1] = true;
            readyToShoot[1] = true;
            Destroy(other.gameObject);
            gunsInHand[1].SetActive(true);
        }

    }
}

