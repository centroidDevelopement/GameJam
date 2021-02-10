using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int damageTaken;
    public int health;
    public int maxHealth = 5;

    public Transform lastCheckPoint;
    public GameObject[] hearts;

    public Animator animator;

    private void Start()
    {
        maxHealth = 5;
    }

    private void Update()
    {
        health = maxHealth - damageTaken;
        if (health <= 0)
            die();

        for (int i = 0; i < maxHealth; i++)
        {
            if(i < health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void takedamage(int damage)
    {
        damageTaken += damage;
    }

    void die()
    {
        
        gameObject.transform.position = lastCheckPoint.position;
        damageTaken = 0;
        animator.SetTrigger("Die");
    }

}
