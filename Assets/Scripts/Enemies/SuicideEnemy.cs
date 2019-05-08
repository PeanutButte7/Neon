using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SuicideEnemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public float idleDistance;

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
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(deathAttack, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // When player is too far do:
        if (Vector2.Distance(transform.position, _player.position) > idleDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
        }
        // When player is too close do:
        else if (Vector2.Distance(transform.position, _player.position) <= idleDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().TakeDamage(damage);
        }
    }
}

