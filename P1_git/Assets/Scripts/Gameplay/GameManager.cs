using System.Collections;
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

    public GameObject currentPlayerGameObj;

    //debug
    public GameObject enemyPrefabPrism;
    public GameObject enemyPrefabCube;
    public GameObject HBPrefab;
    public GameObject healthBar;
    public GameObject Target;
    public GameObject laserPrefab;
    public GameObject pistolPrefab;
    public CDBarScript cdbarScript;

    //debug end

    private Target targetScript;
    private HealthBar healthBarScript;
    private ShootingManager shootingManager;
    

    public bool currentPlayer1 = true;
    public bool readyToChangePlayer = true;
    //public bool p1ReadyToShootManager;

    public Text playerChangeCDText;

    public Vector3 rampOffset, enemySpawnPoint;

    public float playerChangeCD;

    //private string keyToChangePlayer = "F";
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerGameObj = player1;
        targetScript = Target.GetComponent<Target>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cdbarScript = FindObjectOfType<CDBarScript>().GetComponent<CDBarScript>();
        PlayerChange();
        DebugActions();
        shootingManager = currentPlayerGameObj.GetComponent<ShootingManager>();
    }

    void DebugActions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject enemy = Instantiate(enemyPrefabCube, enemySpawnPoint, enemyPrefabCube.transform.rotation);
            healthBar = Instantiate(HBPrefab, enemySpawnPoint, HBPrefab.transform.rotation);
            healthBar.GetComponent<HealthBar>().sthToFollow = enemy.transform;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject enemyprism = Instantiate(enemyPrefabPrism, enemySpawnPoint, enemyPrefabPrism.transform.rotation);
            healthBar = Instantiate(HBPrefab, enemySpawnPoint, HBPrefab.transform.rotation);
            healthBar.GetComponent<HealthBar>().sthToFollow = enemyprism.transform;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject laser = Instantiate(laserPrefab, new Vector3(-10, 1, -20), laserPrefab.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject laser = Instantiate(pistolPrefab, new Vector3(10, 1, -20), pistolPrefab.transform.rotation);

        }
    }
    void PlayerChange()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentPlayer1 && readyToChangePlayer)
        {
            currentPlayerGameObj = player2;
            shootingManager.readyToShoot[1] = true;

            player1.GetComponent<PlayersMovement>().enabled = false;
            player2.GetComponent<PlayersMovement>().enabled = true;

            currentPlayer1 = false;
            readyToChangePlayer = false;

            StartCoroutine(PlayerChangeCD());

            cdbarScript.AddABar("PlayerChangeCD");

            player2.transform.position = player1.transform.position + new Vector3(0, 4, 0);
            ReplaceP1WithBoost();
        }
        else if (Input.GetKeyDown(KeyCode.F) && !currentPlayer1 && readyToChangePlayer)
        {
            currentPlayerGameObj = player1;
            shootingManager.readyToShoot[1] = true;

            player1.GetComponent<PlayersMovement>().enabled = true;
            player2.GetComponent<PlayersMovement>().enabled = false;

            currentPlayer1 = true;
            readyToChangePlayer = false;

            StartCoroutine(PlayerChangeCD());

            cdbarScript.AddABar("PlayerChangeCD");

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

    void ReplaceP1WithBoost()
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
