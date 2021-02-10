using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public bool enemy;

    private void Start()
    {
        Destroy(gameObject, 10f);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        if(collision.gameObject.GetComponent<Enemy>() != null && !enemy)
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(1);
        }

        var player = collision.gameObject.GetComponent<playerHealth>();

        if(player != null && enemy)
        {
            player.takedamage(1);
        }

        Destroy(gameObject);
    }
}
