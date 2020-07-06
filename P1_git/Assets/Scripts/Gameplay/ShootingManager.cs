using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public Quaternion hitRotation;

    public GameObject FirePoint, GameManagerScriptTo, bulletPrefab;

    private GameManager managerScript;
    private CDBarScript cDBarScript;

    public ParticleSystem laserParticle, laserPartToDestroy;

    private LineRenderer lineRenderer;

<<<<<<< HEAD
    public bool[] readyToShoot;
    private bool laserReadyToShoot = false, pistolReadyToShoot = false, circleReadyToShoot = false, rocketReadyToShoot = false;
    public bool canShoot = true, lasCanShoot = true;

    private bool laserGun, pistolGun, circleGun, rocketGun;
    public bool[] guns;

    public float laserOverLoadCD, laserpartOf, laserCurrentDamageDeal, pistolShootCd;
=======
    public bool laserReadyToShoot = false, pistolReadyToShoot = false, circleReadyToShoot = false, rocketReadyToShoot = false;
    public bool canShoot = true;

    public float lasershootCD, laserpartOf, laserCurrentDamageDeal;
>>>>>>> parent of a9e0f2e... 2 перса стриляют
    public float pistolShootForse = 100;

    public bool[] guns;
    public bool laserGun, pistolGun, circleGun, rocketGun;

    private void Update()
    {
        LaserShot();
        PistolShot();
    }

    private void Start()
    {
<<<<<<< HEAD
        cDBarScript = FindObjectOfType<CDBarScript>().GetComponent<CDBarScript>();
        //gunsInHand = new GameObject[4] /*{ laserInHand, pistolInHand, circleInHand, rocketInHand}*/;

        guns = new bool[4] {laserGun = false, pistolGun = false, circleGun = false, rocketGun = false };
        for(int i = 0; i < guns.Length; i++) { guns[i] = false; }

        readyToShoot = new bool[4] { laserReadyToShoot, pistolReadyToShoot, circleReadyToShoot, rocketReadyToShoot };
        for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }
=======
        bool[] guns = new bool[4] {laserGun, pistolGun, circleGun, rocketGun};
>>>>>>> parent of a9e0f2e... 2 перса стриляют

        managerScript = GameManagerScriptTo.GetComponent<GameManager>();
        lineRenderer = GetComponent<LineRenderer>();
        laserPartToDestroy = Instantiate(laserParticle);
    }

    public void LaserShot()
    {
<<<<<<< HEAD
        if (Input.GetButton("Fire1") && /*managerScript.currentPlayer1 &&*/ guns[0] && canShoot && readyToShoot[0] && lasCanShoot)
=======
        if (Input.GetButton("Fire1") && managerScript.currentPlayer1 && laserReadyToShoot && canShoot && laserGun)
>>>>>>> parent of a9e0f2e... 2 перса стриляют
        {
            ///p1Shoot();
            RaycastHit hitInfo;

            cDBarScript.AddABar("laserShotCDDown");

            Ray ray = new Ray(FirePoint.transform.position, FirePoint.transform.forward);

            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log(hitInfo.transform.name);

                Target targetScript = hitInfo.transform.GetComponent<Target>();
                if (targetScript != null)
                {
                    targetScript.TakeDamage(Time.deltaTime * laserCurrentDamageDeal);
                }
            }
            lineRenderer.SetPosition(0, FirePoint.transform.position);
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
        lasCanShoot = false;
        yield return new WaitForSeconds(3);
        lasCanShoot = true;
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
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetButton("Fire1") && readyToShoot[1] && guns[1] && canShoot)
=======
        if (Input.GetButton("Fire1") && managerScript.currentPlayer1 && pistolReadyToShoot && pistolGun && canShoot)
>>>>>>> parent of a9e0f2e... 2 перса стриляют
=======
        if (Input.GetButton("Fire1") && /*managerScript.currentPlayer1 &&*/ readyToShoot[1] && guns[1] && canShoot)
>>>>>>> parent of 1e88a64... Для отката(начал делать один шутиг манагер)
        {
            GameObject bullet = Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
            Rigidbody bulRB = bullet.GetComponent<Rigidbody>();
            bulRB.AddForce(FirePoint.transform.forward * pistolShootForse, ForceMode.Impulse);
            pistolReadyToShoot = false;
            StartCoroutine(shootCd());
            cDBarScript.AddABar("PistolCD");
        }

        IEnumerator shootCd()
        {
            yield return new WaitForSeconds(0.2f);
            pistolReadyToShoot = true;
        }
    }
}
