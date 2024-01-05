using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionState_Fireblack : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    
    [Header("Player")]
    private Transform Player;

    [Header("Ant")]
    [SerializeField]private float Speed;
    private Transform AntTransform;

    [Header("Distance Attack")]
    [SerializeField] private float PersecutionDistance;
    [SerializeField] private float AttackDistance;
    private float distance;

    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] private float restartTime;

    void OnEnable(){

        timer = restartTime;
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindWithTag("Player").transform;
        AntTransform = GetComponent<Transform>();
    }

    
    void Update()
    {
        //Perseguir jugador
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.position.x, Player.position.y), Speed * Time.deltaTime);
        Distance();
        CorroborateDistance();
        
    }

    private void Distance(){

        if (Player != null && AntTransform != null)
        {
            // Calcula la distancia entre el player y la hormiga.
            distance = Vector3.Distance(Player.position, AntTransform.position);

        }
    }

    private void CorroborateDistance(){

        if(distance > PersecutionDistance)
        {
            timer -= Time.deltaTime;
            if(timer <= 0) StateMach.ActivateState(StateMach.stateArray[0]);
            
        } else {

            timer = restartTime;
        }


        if(distance < AttackDistance) StateMach.ActivateState(StateMach.stateArray[3]);
        
    }
}
