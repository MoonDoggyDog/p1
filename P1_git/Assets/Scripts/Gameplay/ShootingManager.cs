using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public Quaternion hitRotation;

    public GameObject FirePoint, GameManagerScriptTo, bulletPrefab;

    private GameManager managerScript;

    public ParticleSystem laserParticle, laserPartToDestroy;

    private LineRenderer lineRenderer;

    public bool laserReadyToShoot = false, pistolReadyToShoot = false, circleReadyToShoot = false, rocketReadyToShoot = false;
    public bool canShoot = true;

    public float lasershootCD, laserpartOf, laserCurrentDamageDeal;
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
        bool[] guns = new bool[4] {laserGun, pistolGun, circleGun, rocketGun};

        managerScript = GameManagerScriptTo.GetComponent<GameManager>();
        lineRenderer = GetComponent<LineRenderer>();
        laserPartToDestroy = Instantiate(laserParticle);
    }

    public void LaserShot()
    {
        if (Input.GetButton("Fire1") && managerScript.currentPlayer1 && laserReadyToShoot && canShoot && laserGun)
        {
            ///p1Shoot();
            RaycastHit hitInfo;


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

            lineRenderer.SetPosition(0, new Vector3(0, -1, 0));
            lineRenderer.SetPosition(1, new Vector3(0, -1, 0));
            laserPartToDestroy.Stop();
        }
    }
    public void PistolShot()
    {
        if (Input.GetButton("Fire1") && managerScript.currentPlayer1 && pistolReadyToShoot && pistolGun && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
            Rigidbody bulRB = bullet.GetComponent<Rigidbody>();
            bulRB.AddForce(FirePoint.transform.forward * pistolShootForse, ForceMode.Impulse);
            pistolReadyToShoot = false;
            StartCoroutine(shootCd());
        }

        IEnumerator shootCd()
        {
            yield return new WaitForSeconds(0.2f);
            pistolReadyToShoot = true;
        }
    }
}
