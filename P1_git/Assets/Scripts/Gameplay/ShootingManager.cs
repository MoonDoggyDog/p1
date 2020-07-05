using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public Quaternion hitRotation;

    public GameObject FirePoint, GameManagerScriptTo, bulletPrefab;

    private GameObject laserInHand, pistolInHand, circleInHand, rocketInHand;
    public GameObject[] gunsInHand = new GameObject[4] ;

    private GameManager managerScript;

    public ParticleSystem laserParticle, laserPartToDestroy;

    private LineRenderer lineRenderer;

    public bool[] readyToShoot;
    private bool laserReadyToShoot = false, pistolReadyToShoot = false, circleReadyToShoot = false, rocketReadyToShoot = false;
    public bool canShoot = true;

    private bool laserGun, pistolGun, circleGun, rocketGun;
    public bool[] guns;

    public float lasershootCD, laserpartOf, laserCurrentDamageDeal, pistolShootCd;
    public float pistolShootForse = 100;

    private void Update()
    {
        LaserShot();
        PistolShot();
        
    }

    private void Start()
    {
        //gunsInHand = new GameObject[4] /*{ laserInHand, pistolInHand, circleInHand, rocketInHand}*/;

        guns = new bool[4] {laserGun = false, pistolGun = false, circleGun = false, rocketGun = false };
        for(int i = 0; i < guns.Length; i++) { guns[i] = false; }

        readyToShoot = new bool[4] { laserReadyToShoot, pistolReadyToShoot, circleReadyToShoot, rocketReadyToShoot };
        for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }

        managerScript = GameManagerScriptTo.GetComponent<GameManager>();
        lineRenderer = GetComponent<LineRenderer>();
        laserPartToDestroy = Instantiate(laserParticle);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("kek");
        if (other.CompareTag("laser"))
        //if (other.name == "laserGo")
        {
            //Debug.Log("keklaser");
            //Debug.Log(guns.Length);
            for (int i = 0; i < guns.Length; i++) { guns[i] = false; }
            for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }
            for (int i = 0; i < gunsInHand.Length; i++) { gunsInHand[i].SetActive(false);  }
            guns[0] = true;
            readyToShoot[0] = true;
            Destroy(other.gameObject);
            gunsInHand[0].SetActive(true);
        }

        if (other.gameObject.CompareTag("pistol"))
        //if (other.name == "pistolGo")
        {
            //Debug.Log("kekois");
            for (int i = 0; i < guns.Length; i++) { guns[i] = false; }
            for (int i = 0; i < readyToShoot.Length; i++) { readyToShoot[i] = false; }
            for (int i = 0; i < gunsInHand.Length; i++) { gunsInHand[i].SetActive(false); }
            guns[1] = true;
            readyToShoot[1] = true;
            Destroy(other.gameObject);
            gunsInHand[1].SetActive(true);
        }    
        
    }

    public void LaserShot()
    {
        if (Input.GetButton("Fire1") && /*managerScript.currentPlayer1 &&*/ guns[0] && canShoot && readyToShoot[0])
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
        if (Input.GetButton("Fire1") && /*managerScript.currentPlayer1 &&*/ readyToShoot[1] && guns[1] && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
            Rigidbody bulRB = bullet.GetComponent<Rigidbody>();
            bulRB.AddForce(FirePoint.transform.forward * pistolShootForse, ForceMode.Impulse);
            readyToShoot[1] = false;
            StartCoroutine(shootCd());
        }

        IEnumerator shootCd()
        {
            yield return new WaitForSeconds(pistolShootCd);
            readyToShoot[1] = true;
        }
    }
}
