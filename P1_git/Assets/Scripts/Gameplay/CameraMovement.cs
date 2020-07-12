using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameManager gameManager;

    public Vector3 offset;

    public Transform p1transform;
    public Transform p2transform;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.currentPlayer1 == true) 
        {
            //transform.position = player1.transform.position + offset;
            Vector3 p1Pos = p1transform.position + offset;
            Vector3 smoothP1Pos = Vector3.Lerp(transform.position, p1Pos, 0.1f);
            transform.position = smoothP1Pos;
        }else if (!gameManager.currentPlayer1)
        {
            //transform.position = player2.transform.position + offset;
            Vector3 p2Pos = p2transform.position + offset;
            Vector3 smoothP2Pos = Vector3.Lerp(transform.position, p2Pos, 0.1f);
            transform.position = smoothP2Pos;
        }
    }
}
