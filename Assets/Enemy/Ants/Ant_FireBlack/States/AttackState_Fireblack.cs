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

    


    void OnEnable()
    {
        StateMach = GetComponent<StateMachine>();
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;

        StartCoroutine(ShootProjectile());
        
    }

    IEnumerator ShootProjectile(){

        Instantiate(ProjectilePrefabs, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        StateMach.ActivateState(StateMach.stateArray[3]);
        
    }
}
