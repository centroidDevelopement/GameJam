using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;

    public Transform target;
    public Transform gunRotationPoint;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce;

    public GameObject body;


    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public void die()
    {
        Instantiate(body, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        InvokeRepeating("shoot", 0, .5f);
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

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
