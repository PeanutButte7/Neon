using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineAttack : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public float growSpeed;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    private Transform _player;
    private Vector2 _target;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _target = new Vector2(_player.position.x, _player.position.y);
        
        Invoke("DestroyProjectile", lifeTime); // Runs function after some time (lifetime)
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, speed * Time.deltaTime);
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Health>().TakeDamage(damage);
            }
            DestroyProjectile();
        } else if (Math.Abs(transform.position.x - _target.x) < 0.25 && Math.Abs(transform.position.y - _target.y) < 0.25)
        {
            DestroyProjectile();
        }
        
        transform.localScale += new Vector3(growSpeed, 0, 0);
    }

    private void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
