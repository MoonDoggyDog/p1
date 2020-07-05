using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDBarScript : MonoBehaviour
{
    private bool[] sequence = new bool[3];

    public GameObject[] CDBarGameObjects = new GameObject[4];
    public GameObject player1;
    public GameObject player2;

    public GameManager gameManager;
    public ShootingManager shootingManager;

    public Vector3 offset;

    public float numAddPlayerChangeCD = 0, numAddPistolCd = 0;

    private void Start()
    {
        shootingManager = FindObjectOfType<ShootingManager>().GetComponent<ShootingManager>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        //sequence[] =  {false, false, false};
        //CDBarGameObjects = new GameObject[4];
        for(int i = 0; i < CDBarGameObjects.Length - 1; i++) { CDBarGameObjects[i].SetActive(false); }
    }

    private void Update()
    {
        AddPlayerChangeCD();
        AddPistolCd();
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
            numAddPistolCd = shootingManager.pistolShootCd;
            CDBarGameObjects[0].SetActive(true);
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
            CDBarGameObjects[0].transform.localScale = new Vector3(numAddPistolCd / shootingManager.pistolShootCd, 1, 1);
        }
        else
        {
            CDBarGameObjects[0].SetActive(false);
        }
    }
}
