﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject baricadePrefab;
    private GameObject baricade;
    private GameObject ramp;
    public GameObject rampPrefab;

    public P1Shooting p1Shooting;

    public bool currentPlayer1 = true;
    public bool readyToChangePlayer = true;
    //public bool p1ReadyToShootManager;

    public Text playerChangeCDText;

    public Vector3 rampOffset;

    public float playerChangeCD;

    //private string keyToChangePlayer = "F";
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        p1Shooting = player1.GetComponent<P1Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerChange();
    }

    void PlayerChange()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentPlayer1 && readyToChangePlayer)
        {
            player1.GetComponent<PlayersMovement>().enabled = false;
            player2.GetComponent<PlayersMovement>().enabled = true;
            currentPlayer1 = false;
            readyToChangePlayer = false;
            StartCoroutine(PlayerChangeCD());
            player2.transform.position = player1.transform.position + new Vector3(0, 4, 0);
            ReplaceP2WithBoost();
            p1Shooting.p1ReadyToShoot = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !currentPlayer1 && readyToChangePlayer)
        {
            player1.GetComponent<PlayersMovement>().enabled = true;
            player2.GetComponent<PlayersMovement>().enabled = false;
            currentPlayer1 = true;
            readyToChangePlayer = false;
            StartCoroutine(PlayerChangeCD());
            player1.transform.position = player2.transform.position;
            ReplaceP2WithBaricade();
        }
    }

    void ReplaceP2WithBaricade()
    {
        player2.SetActive(false);
        player1.SetActive(true);
        baricade = Instantiate(baricadePrefab, player2.transform.position, player2.transform.rotation);
        Destroy(ramp);
    }

    void ReplaceP2WithBoost()
    { 
        player1.SetActive(false);
        player2.SetActive(true);
        ramp = Instantiate(rampPrefab, player2.transform.position - rampOffset, baricadePrefab.transform.rotation);
        Destroy(baricade);
    }

    public IEnumerator PlayerChangeCD()
    {
        yield return new WaitForSeconds(playerChangeCD);
        readyToChangePlayer = true;
    }
}