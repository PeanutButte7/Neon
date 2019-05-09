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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            // If player is not crouching
            if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isCrouching)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().TakeDamage(damage);
                Instantiate(destroyEffect, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
            }
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
