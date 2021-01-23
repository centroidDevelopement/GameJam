using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Movespeed = 5;
    public Rigidbody2D rb;
    public Camera cam;
    public Transform rotationPoint;

    Vector2 movement;
    Vector2 mousePos;

    private void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       mousePos = cam.ScreenToWorldPoint( Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Movespeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos  - (Vector2)rotationPoint.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        rotationPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
