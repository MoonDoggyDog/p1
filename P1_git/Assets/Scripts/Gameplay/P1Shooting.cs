using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Shooting : MonoBehaviour
{
    public Quaternion hitRotation;

    public GameObject p1FirePoint;
    private GameManager managerScript;
    public GameObject p1GameManagerScriptTo;

    public ParticleSystem laserParticle;
    private ParticleSystem laserPartToDestroy;

    private LineRenderer lineRenderer;

    public bool p1ReadyToShoot = true;
    public bool canShoot = true;

    public float shootCD;
    public float partOf;
    public float currentDamageDeal;

    private void Start()
    {
        managerScript = p1GameManagerScriptTo.GetComponent<GameManager>();
        lineRenderer = GetComponent<LineRenderer>();
        laserPartToDestroy = Instantiate(laserParticle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && managerScript.currentPlayer1 && p1ReadyToShoot && canShoot) 
        {
            ///p1Shoot();
            RaycastHit hitInfo;


            Ray ray = new Ray(p1FirePoint.transform.position, p1FirePoint.transform.forward);

            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log(hitInfo.transform.name);

                Target targetScript = hitInfo.transform.GetComponent<Target>();
                if (targetScript != null)
                {
                    targetScript.TakeDamage(Time.deltaTime * currentDamageDeal);
                }
            }
            lineRenderer.SetPosition(0, p1FirePoint.transform.position);
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
}
