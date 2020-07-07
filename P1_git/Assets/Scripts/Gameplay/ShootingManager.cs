using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject currentPlayer;

    private GameManager managerScript;
    private CDBarScript cDBarScript;
    private PScript playerScript;

    public LineRenderer lineRenderer;

    public ParticleSystem laserParticle, laserPartToDestroy;

    private void Update()
    {
        LaserShot();
        PistolShot();

        managerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        currentPlayer = managerScript.currentPlayerGameObj;

        playerScript = currentPlayer.GetComponent<PScript>();
    }

    private void Start()
    {
        cDBarScript = FindObjectOfType<CDBarScript>().GetComponent<CDBarScript>();

        lineRenderer = GetComponent<LineRenderer>();
    }

    public void LaserShot()
    {
        if (Input.GetButton("Fire1") && /*managerScript.currentPlayer1 &&*/playerScript.guns[0] &&  playerScript.canShoot && playerScript.readyToShoot[0] &&playerScript.lasCanShoot)
        {
            ///p1Shoot();
            RaycastHit hitInfo;

            cDBarScript.AddABar("laserShotCDDown");

            Ray ray = new Ray(playerScript.FirePoint.transform.position, playerScript.FirePoint.transform.forward);

            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log(hitInfo.transform.name);

                Target targetScript = hitInfo.transform.GetComponent<Target>();
                if (targetScript != null)
                {
                    targetScript.TakeDamage(Time.deltaTime * playerScript.laserCurrentDamageDeal);
                }
            }
            lineRenderer.SetPosition(0, playerScript.FirePoint.transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            laserPartToDestroy.transform.position = hitInfo.point;
            laserPartToDestroy.Play();
        }
        else
        {
            cDBarScript.AddABar("laserShotCDUp");
            lineRenderer.SetPosition(0, new Vector3(0, -1, 0));
            lineRenderer.SetPosition(1, new Vector3(0, -1, 0));
            laserPartToDestroy.Stop();
        }
    }

    public IEnumerator LaserOverload()
    {
        playerScript.lasCanShoot = false;
        yield return new WaitForSeconds(3);
        playerScript.lasCanShoot = true;
    }


    ///Если нада лазером стрелять раз в ... сек
    /*void p1Shoot()
    {
        RaycastHit hitInfo;

        Ray ray = new Ray(p1FirePoint.transform.position,p1FirePoint.transform.forward);
        //Debug.DrawRay(p1FirePoint.transform.position, p1FirePoint.transform.forward * 1000);
        if(Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);

            Target targetScript = hitInfo.transform.GetComponent<Target>();
            if(targetScript != null)
            {
                targetScript.TakeDamage(currentDamageDeal);
            }
        }

        ParticleSystem laserPartToDestroy = Instantiate(laserParticle, hitInfo.point, laserParticle.transform.rotation);

        lineRenderer.SetPosition(0, p1FirePoint.transform.position);
        lineRenderer.SetPosition(1, hitInfo.point);

        p1ReadyToShoot = false;
        StartCoroutine(p1ShootCD());
    }

    private IEnumerator p1ShootCD()
    {
        yield return new WaitForSeconds(shootCD / partOf);
        lineRenderer.SetPosition(0, new Vector3(0, -1, 0));
        lineRenderer.SetPosition(1, new Vector3(0, -1, 0));

        yield return new WaitForSeconds((shootCD / partOf) * (partOf - 1));
        p1ReadyToShoot = true;
    }*///

    public void PistolShot()
    {
        if (Input.GetButton("Fire1") && playerScript.readyToShoot[1] && playerScript.guns[1] && playerScript.canShoot)
        {
            GameObject bullet = Instantiate(playerScript.bulletPrefab, playerScript.FirePoint.transform.position, playerScript.FirePoint.transform.rotation);
            Rigidbody bulRB = bullet.GetComponent<Rigidbody>();
            bulRB.AddForce(playerScript.FirePoint.transform.forward * playerScript.pistolShootForse, ForceMode.Impulse);
            playerScript.readyToShoot[1] = false;
            StartCoroutine(shootCd());
            cDBarScript.AddABar("PistolCD");
        }

        IEnumerator shootCd()
        {
            yield return new WaitForSeconds(playerScript.pistolShootCd);
            playerScript.readyToShoot[1] = true;
        }
    }
}
