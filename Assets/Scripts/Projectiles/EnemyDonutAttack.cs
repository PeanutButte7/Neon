using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDonutAttack : MonoBehaviour
{
    public float lifeTime;
    public int damage;
    public float growSpeed;

    public GameObject destroyEffect;

    void Start()
    {

        Invoke("DestroyProjectile", lifeTime); // Runs function after some time (lifetime)
    }

    void Update()
    {
        transform.localScale += new Vector3(growSpeed, growSpeed, 0);
    }

    private void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}