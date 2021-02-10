using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200;
    public float nextWaypointDistance = 3f;

    public Transform enemyGfx;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndofpath;

    Seeker seeker;
    Rigidbody2D rb;

    bool spottedPlayer = false;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    void updatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofpath = true;
            return;
        }
        else
        {
            reachedEndofpath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(force.x >= 0.01f)
        {
            enemyGfx.localScale = new Vector3(-1f, 1f, 1f);
        }else if(force.x <= -0.01f)
        {
            enemyGfx.localScale = new Vector3(1f, 1f, 1f);
        }



    }
    bool t = true;
    private void Update()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;

        if(spottedPlayer && t)
        {
            InvokeRepeating("updatePath", 0, .5f);
            t = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spottedPlayer = true;
        }
    }
}
