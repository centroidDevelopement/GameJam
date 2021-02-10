using System.Collections;
using System.Collections.Generic;
using Unity.MPE;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<playerHealth>().lastCheckPoint = transform;
            collision.gameObject.GetComponent<Animator>().SetTrigger("checkpoint");
        }
    }
}
