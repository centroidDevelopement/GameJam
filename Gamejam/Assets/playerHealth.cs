using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int damageTaken;
    public int health;
    public int maxHealth = 5;

    private void Start()
    {
        maxHealth = 5;
    }

    private void Update()
    {
        health = maxHealth - damageTaken;
    }

    public void takedamage(int damage)
    {
        damageTaken += damage;
    }

}
