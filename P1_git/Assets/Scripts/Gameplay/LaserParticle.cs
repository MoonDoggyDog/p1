using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticle : MonoBehaviour
{
    public float timeLeft = 2f;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
