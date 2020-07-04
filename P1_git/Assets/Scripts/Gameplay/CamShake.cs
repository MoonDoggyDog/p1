using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float amplitude;
    public float timeToShake;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ShakeTheCam();
        }
    }
    void ShakeTheCam()
    {
        while (timeToShake >= 0)
        {
            float xShake = Random.Range(-1, 1) * amplitude;
            float zShake = Random.Range(-1, 1) * amplitude;
            transform.position = new Vector3(xShake, 0, zShake);

            timeToShake -= Time.deltaTime;
        }
        transform.position = new Vector3(0, 0, 0);
    }
}
