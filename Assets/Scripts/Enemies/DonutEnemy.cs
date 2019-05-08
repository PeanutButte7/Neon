using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DonutEnemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public float idleDistance;
    public float moveAwayDistance;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Transform _player;

    public GameObject deathEffect;
    public GameObject deathAttack;
    public GameObject destroyEffect;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, _player.position);

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Instantiate(deathAttack, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // When player is too far move randomly
        if (distanceFromPlayer > idleDistance)
        {
            MoveRandomly();
        }
        // When player is too close move away till it reaches idle distance
        else if (distanceFromPlayer <= moveAwayDistance)
        {
            if (moveAwayDistance >= distanceFromPlayer && distanceFromPlayer <= idleDistance || distanceFromPlayer < moveAwayDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.position, -speed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void MoveRandomly()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}