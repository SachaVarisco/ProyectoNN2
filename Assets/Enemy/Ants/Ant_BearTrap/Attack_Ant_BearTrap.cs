using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ant_BearTrap : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float damage;
    [SerializeField] private float AttackTime;
    
    private GameObject Player;
    private float PlayerSpeed;

    private bool PlayerInTrap = false;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerSpeed = Player.GetComponent<PlayerUtils>().speed;
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

        if(PlayerInTrap) Player.GetComponent<PlayerUtils>().TakeDamage(damage);
        Destroy(this.gameObject);

    }
}
