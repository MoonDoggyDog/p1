using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform toFollow;

    public Vector3 offset;

    public float smoothnesSpeed;
    // Update is called once per frame
    void Update()
    {
        Vector3 toFollowPos = toFollow.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, toFollowPos, smoothnesSpeed);
        transform.position = smoothPos;
    }
}
