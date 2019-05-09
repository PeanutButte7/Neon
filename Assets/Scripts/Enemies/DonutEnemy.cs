using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DonutEnemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float idleDistanceFrom;
    public float idleDistanceTo;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Transform _player;

    public GameObject deathEffect;
    public GameObject destroyEffect;

    public GameObject attack;
    public float startTimeBtwAttacks;
    private float _timeBtwAttacks;
    private float _distanceFromPlayer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        if (_player != null)
        {
            _distanceFromPlayer = Vector2.Distance(transform.position, _player.position);
        }

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // When player is too far:
        if (_distanceFromPlayer > idleDistanceTo)
        {
            MoveRandomly();
        }
        // When player is too close:
        else if (_distanceFromPlayer < idleDistanceFrom)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, -speed * Time.deltaTime);
        }
        // Stand still and attack
        else
        {
            if (_timeBtwAttacks <= 0)
            {
                Instantiate(attack, transform.position, Quaternion.identity);
                _timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                _timeBtwAttacks -= Time.deltaTime;
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