using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;

    public ParticleSystem bulletTalePrefab;
    public ParticleSystem bulletTale;
    public ParticleSystem bulletBum;

    public GameObject p1;

    private void Start()
    {
        bulletTale = Instantiate(bulletTalePrefab, transform.position, transform.rotation);
    }

    private void FixedUpdate()
    {
        bulletTale.transform.position = transform.position;
        bulletTale.transform.rotation = transform.rotation;
    }

    /*private void OnCollisionStay(Collision collision)
    {
        ParticleSystem bb = Instantiate(bulletBum, transform.position, transform.rotation);
        Destroy(bb.gameObject, 2);
        Destroy(gameObject);
        bulletTale.Stop();
        Destroy(bulletTale.gameObject, 2);
        if (collision.gameObject.CompareTag("Target"))
        {
            Target target = collision.gameObject.GetComponent<Target>();
            target.TakeDamage(bulletDamage);
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem bb = Instantiate(bulletBum, transform.position, bulletBum.transform.rotation);
        Destroy(bb.gameObject, 2);
        Destroy(gameObject);
        bulletTale.Stop();
        Destroy(bulletTale.gameObject, 2);
        if (collision.gameObject.CompareTag("Target"))
        {
            Target target = collision.gameObject.GetComponent<Target>();
            target.TakeDamage(bulletDamage);
        }
    }
}    
