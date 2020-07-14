using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefabPrism;
    public GameObject enemyPrefabCube;
    public GameObject HBPrefab;
    public GameObject healthBar;
    public GameObject laserPrefab;
    public GameObject pistolPrefab;
    

    public Vector3 enemySpawnPoint;

    void Update()
    {
        DebugActions();
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
}
