using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{ 
    public Transform sthToFollow;
    public Transform HB2;

    public Vector3 HbOffset;

    public float scale = 0.25f;
    private float sthHP;
    private float sthMaxHp;

    private void Update()
    {
        if (sthToFollow)
        {
            Vector3 sthPos = sthToFollow.position + HbOffset;
            Vector3 smoothP1Pos = Vector3.Lerp(transform.position, sthPos, 0.13f);
            transform.position = smoothP1Pos;
            sthHP = sthToFollow.gameObject.GetComponent<Target>().healthPoints;
            sthMaxHp = sthToFollow.gameObject.GetComponent<Target>().maxHP;
            scale = sthHP / sthMaxHp;
            HB2.transform.localScale = new Vector3(scale, 1, 1);
        }
    }

    /*public void ChangeHP()
    {
        sthHP = sthToFollow.gameObject.GetComponent<Target>().healthPoints;
        sthMaxHp = sthToFollow.gameObject.GetComponent<Target>().maxHP;
        scale = sthHP / sthMaxHp;
        HB2.transform.localScale = new Vector3(scale, 1, 1);
    }*/
}
