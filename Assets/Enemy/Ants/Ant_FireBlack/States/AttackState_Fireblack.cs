using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_Fireblack : MonoBehaviour
{
    
    [Header("StateMachine")]
    private StateMachine StateMach;

    [Header("Player")]
    private Transform Player;

    [Header("Ant")]
    private Transform AntTransform;

    [Header("Projectile")]
    [SerializeField] private GameObject ProjectilePrefabs;

    [Header("Distance")]
    [SerializeField] private float AttackDistance;
    private float distance;

    [Header("Timer")]
    [SerializeField] private float timeBetweenShoots;

    private bool shoot = true;
    


    void OnEnable()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindWithTag("Player").transform;
        AntTransform = GetComponent<Transform>();


        shoot = true;
        StartCoroutine(ShootProjectile());
    }

    
    void Update()
    {
        Distance();
        
    }

    private void Distance(){

        if (Player != null && AntTransform != null)
        {
            // Calcula la distancia entre el player y la hormiga.
            distance = Vector3.Distance(Player.position, AntTransform.position);

        }

        if(distance > AttackDistance) 
        {
            shoot = false;
            StateMach.ActivateState(StateMach.stateArray[1]);
        }
    }

    IEnumerator ShootProjectile(){

        while (shoot == true)
        {
            Instantiate(ProjectilePrefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenShoots);
        }
        
    }
}
