﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void Start()
    {
        Destroy(gameObject, 10f);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(1);
        }

        Destroy(gameObject);
    }
}
