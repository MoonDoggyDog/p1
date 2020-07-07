using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDBarScript : MonoBehaviour
{

    public GameObject currentPlayer;

    private bool[] sequence = new bool[3];

    public bool AddLaserShotCDIsKeyDown;

    public GameObject[] CDBarGameObjects = new GameObject[4];
    public GameObject player1;
    public GameObject player2;

    public GameManager gameManager;
    public ShootingManager shootingManager;
    private PScript playerScript;

    public Vector3 offset;

    public float numAddPlayerChangeCD = 0, numAddPistolCd = 0, numAddLaserCD = 0;

    private void Start()
    {
        currentPlayer = gameManager.currentPlayerGameObj;

        playerScript = currentPlayer.GetComponent<PScript>();

        shootingManager = player1.GetComponent<ShootingManager>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        //sequence[] =  {false, false, false};
        //CDBarGameObjects = new GameObject[4];
        for(int i = 0; i < CDBarGameObjects.Length - 1; i++) { CDBarGameObjects[i].SetActive(false); }
        numAddLaserCD = playerScript.laserOverLoadCD;
    }

    private void Update()
    {
        shootingManager = currentPlayer.GetComponent<ShootingManager>();
        


        AddPlayerChangeCD();
        AddPistolCd();
        AddLaserCD();

        CDBarGameObjects[2].transform.localScale = new Vector3(numAddLaserCD / playerScript.laserOverLoadCD, 1, 1);
    }

    private void FixedUpdate()
    {
        PlayerFollow();
    }

    private void PlayerFollow()
    {
        if (gameManager.currentPlayer1)
        {
            Vector3 playerPos = player1.transform.position + offset;
            Vector3 smoothP1Pos = Vector3.Lerp(transform.position, playerPos, 0.11f);
            transform.position = smoothP1Pos;
        }
        else if (!gameManager.currentPlayer1)
        {
            Vector3 playerPos = player2.transform.position + offset;
            Vector3 smoothP2Pos = Vector3.Lerp(transform.position, playerPos, 0.11f);
            transform.position = smoothP2Pos;
        }
    }

    public void AddABar(string bar)
    {
       if(bar == "PlayerChangeCD")
       {
            numAddPlayerChangeCD = gameManager.playerChangeCD;
            CDBarGameObjects[1].SetActive(true);
       }

       if (bar == "PistolCD")
       {
            numAddPistolCd = playerScript.pistolShootCd;
            CDBarGameObjects[0].SetActive(true);
       }

       if(bar == "laserShotCDDown")
       {
            AddLaserShotCDIsKeyDown = true;
            CDBarGameObjects[2].SetActive(true);
       }else if(bar == "laserShotCDUp")
       {
            AddLaserShotCDIsKeyDown = false;
            //CDBarGameObjects[2].SetActive(false);
       }

    }

    void AddPlayerChangeCD()
    {
        if (numAddPlayerChangeCD > 0)
        {
            numAddPlayerChangeCD -= Time.deltaTime;
            CDBarGameObjects[1].transform.localScale = new Vector3(numAddPlayerChangeCD / gameManager.playerChangeCD, 1, 1);
        }
        else
        {
            CDBarGameObjects[1].SetActive(false);
        }
    }

    void AddPistolCd()
    {
        if (numAddPistolCd > 0)
        {
            numAddPistolCd -= Time.deltaTime;
            CDBarGameObjects[0].transform.localScale = new Vector3(numAddPistolCd / playerScript.pistolShootCd, 1, 1);
        }
        else
        {
            CDBarGameObjects[0].SetActive(false);
        }
    }

    void AddLaserCD()
    {
        if(AddLaserShotCDIsKeyDown && numAddLaserCD > 0)
        {
            numAddLaserCD -= Time.deltaTime;
        }
        else if(numAddLaserCD <= 0)
        {
            //AddLaserShotCDIsKeyDown = false;
            StartCoroutine(shootingManager.LaserOverload());
        }
        if(!AddLaserShotCDIsKeyDown && numAddLaserCD  < playerScript.laserOverLoadCD)
        {

            numAddLaserCD += Time.deltaTime;
            CDBarGameObjects[2].SetActive(true);
        }
    }
}
