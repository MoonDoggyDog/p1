using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float healthPoints;
    public float maxHP;

    public ParticleSystem explosionParticle;

    public GameManager gM;
    public HealthBar healthBarScript;

    public GameObject hB;

    private void Start()
    {
        gM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        maxHP = healthPoints;
        healthBarScript = hB.GetComponent<HealthBar>();
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        //healthBarScript.ChangeHP();
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
        Destroy(gM.healthBar);
    }
}
