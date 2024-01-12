using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private float Speed = 2;
    [SerializeField] private float DamageProjectile = 10;
    private GameObject Player;
    private PlayerUtils LifePlayer;
    private Rigidbody2D Rb;

    private Animator animator;

    

    void Start(){
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        LifePlayer = Player.GetComponent<PlayerUtils>();
        Rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {

        Vector2 directionToPlayer = (Player.transform.position - transform.position).normalized;
        Rb.velocity = directionToPlayer * Speed;
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

     Destroy(gameObject);

     if(other.collider.CompareTag("Player"))
     {
        LifePlayer.TakeDamage(DamageProjectile);
     }
    }

    // private void OnTriggerEnter(Collider other)
    // {

    //     if(other.CompareTag("Player"))
    //     {
    //         LifePlayer.TakeDamage(DamageProjectile);
    //     }

    //     Destroy(gameObject);
    // }
}
