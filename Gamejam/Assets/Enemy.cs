using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;

    public Transform target;
    public Transform gunRotationPoint;
    


    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public void die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(health <= 0)
        {
            die();
        }


        Vector2 lookDir = (Vector2)target.position - (Vector2)gunRotationPoint.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        gunRotationPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
