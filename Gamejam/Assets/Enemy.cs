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
    public GameObject heart;


    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public void die()
    {
        if(Random.Range(0, 6) == 1)
            Instantiate(heart, transform.position, Quaternion.)
        Instantiate(body, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        
    }
    bool t = true;
    private void Update()
    {
        

        if(health <= 0)
        {
            die();
        }

        if(seenPlayer && t)
        {
            InvokeRepeating("shoot", 0, .7f);
            t = false;
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
        bullet.GetComponent<bullet>().enemy = true;
    }
    bool seenPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            seenPlayer = true;
        }
    }

}
