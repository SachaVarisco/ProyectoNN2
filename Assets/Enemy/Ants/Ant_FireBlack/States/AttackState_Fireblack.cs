using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_Fireblack : MonoBehaviour
{
    
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    
    [Header("Projectile")]
    [SerializeField] private GameObject ProjectilePrefabs;

    private Animator animator;

    private RotationSprite rotation;

    


    void OnEnable()
    {
        animator = GetComponent<Animator>();
        StateMach = GetComponent<StateMachine>();
        rotation = GetComponent<RotationSprite>();
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;

        StartCoroutine(ShootProjectile());
        
    }

    IEnumerator ShootProjectile()
    {

        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.2f);

        if(rotation.LookLeft == true)
        {
            Instantiate(ProjectilePrefabs, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity);
        }else{
            Instantiate(ProjectilePrefabs, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
        }
        
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttacking", false);
        StateMach.ActivateState(StateMach.stateArray[3]);
        
    }
}
