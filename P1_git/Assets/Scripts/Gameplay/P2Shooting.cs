using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public GameObject gameManagerScriptTo;
    public float shootForse = 100;
    public GameManager managerScript;
    private bool readyToShoot = true;

    private void Start()
    {
        managerScript = gameManagerScriptTo.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !managerScript.currentPlayer1 && readyToShoot)
        {
            Shoot();
            readyToShoot = false;
            StartCoroutine(shootCd());
        }
    }

    private IEnumerator shootCd()
    {
        yield return new WaitForSeconds(0.2f);
        readyToShoot = true;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulRB = bullet.GetComponent<Rigidbody>();
        bulRB.AddForce(shootPoint.up * shootForse, ForceMode.Impulse);
    }
}
