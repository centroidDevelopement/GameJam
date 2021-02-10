using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        playerHealth helth = FindObjectOfType<playerHealth>();
        helth.damageTaken--;
        if (helth.damageTaken < 0)
            helth.damageTaken = 0;      
        Destroy(gameObject);

    }
}
