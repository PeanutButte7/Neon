using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime); // Runs function after some time (lifetime)
    }
    
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("SuicideEnemy"))
            {
                hitInfo.collider.GetComponent<SuicideEnemy>().TakeDamage(damage);
                DestroyProjectile();
            } 
            else if (hitInfo.collider.CompareTag("DonutEnemy"))
            {
                hitInfo.collider.GetComponent<DonutEnemy>().TakeDamage(damage); 
                DestroyProjectile();
            }
        }
        
        transform.Translate(Time.deltaTime * speed * Vector2.up);
    }

    private void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
