using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float speed;
    public float gravityMod = 5;

    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform player in x, z axes
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        //look at mouse
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(Physics.gravity * gravityMod, ForceMode.Acceleration);
        playerRB.MovePosition(playerRB.position + movement * speed * Time.fixedDeltaTime);
    }
}
