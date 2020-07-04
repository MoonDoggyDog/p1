using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float healthPoints;

    public ParticleSystem explosionParticle;

    

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        ParticleSystem expart = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(expart, 5);
        Destroy(gameObject);
    }
}
