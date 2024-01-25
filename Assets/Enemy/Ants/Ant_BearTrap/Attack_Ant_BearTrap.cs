using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ant_BearTrap : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float damage;
    [SerializeField] private float AttackTime;
    
    [Header("Player")]
    private GameObject Player;
    private float PlayerSpeed;
    private bool PlayerInTrap = false;

    [Header("Animacion")]
    private Animator animator;

    [Header("Fade Out")]
    private SpriteRenderer sprite;
    private bool enemyDeath = false;
    private PolygonCollider2D polygonCollider2D;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerSpeed = Player.GetComponent<PlayerUtils>().speed;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.CompareTag("Player")){

            StartCoroutine(Attack());
        }
 
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if (other.gameObject.CompareTag("Player")){

            other.gameObject.GetComponent<PlayerUtils>().speed = PlayerSpeed / 2;
            PlayerInTrap = true;
 
        }
 
    }

    private void OnCollisionExit2D(Collision2D other) {
        
        if (other.gameObject.CompareTag("Player")){

            other.gameObject.GetComponent<PlayerUtils>().speed = PlayerSpeed;
            PlayerInTrap = false;
 
        }
 
    }


    private IEnumerator Attack()
    {   
        yield return new WaitForSeconds(AttackTime);
        animator.SetBool("isAttacking", true);
        if(PlayerInTrap) Player.GetComponent<PlayerUtils>().TakeDamage(damage);
        yield return new WaitForSeconds(0.5f);
        enemyDeath = true;
        polygonCollider2D.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }

    void FixedUpdate() {
        
        if(enemyDeath) FadeOut();
    }

    private void FadeOut()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 1 * Time.deltaTime);
    }
}
