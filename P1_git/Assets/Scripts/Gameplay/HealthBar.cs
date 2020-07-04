using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform sthToFollow;
    public Vector3 HbOffset;

    private void Update()
    {
        Vector3 sthPos = sthToFollow.position + HbOffset;
        Vector3 smoothP1Pos = Vector3.Lerp(transform.position, sthPos, 0.13f);
        transform.position = smoothP1Pos;
    }
}
