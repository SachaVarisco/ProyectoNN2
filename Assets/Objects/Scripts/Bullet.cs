using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private float bulletSpeed;

    private void Update() 
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }     
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage);
        }    

        Destroy(gameObject);
    }

}
