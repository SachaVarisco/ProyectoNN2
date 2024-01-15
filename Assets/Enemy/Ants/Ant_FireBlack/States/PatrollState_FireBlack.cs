using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState_FireBlack : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;


    [Header("Movement")]
    [SerializeField] private Transform[] WayPoints;

    [Header("Player")]
    private Transform Player;

    [Header("Ant")]
    [SerializeField]private float Speed;
    private Transform AntTransform;

    [Header("Distance")]
    [SerializeField] private float PersecutionDistance;

    [Header("Time Movement")]
    [SerializeField] private float TimeMovement;

    private float distance;
    private Vector3 MoveTo;
    private int RandNum;
    private int RepetitiveNumber;
    


    private void OnEnable(){
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;

        StartCoroutine(Movement());
    }

    
    void Start(){

        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindWithTag("Player").transform;
        AntTransform = GetComponent<Transform>();

    }

    void Update(){

        Distance();
        AntTransform.position = Vector3.MoveTowards(AntTransform.position, MoveTo, Speed * Time.deltaTime);
    }



    private void Distance(){

        if (Player != null && AntTransform != null)
        {
            // Calcula la distancia entre el player y la hormiga.
            distance = Vector3.Distance(Player.position, AntTransform.position);
            
        }

        if(distance < PersecutionDistance)
        {
            StateMach.ActivateState(StateMach.stateArray[1]);   
        }
    }


    IEnumerator Movement(){

        while (true)
        {
            RandNum = Random.Range(0,WayPoints.Length);
            if(RandNum == RepetitiveNumber) RandNum = RandNum + 1;
            if(RandNum == 4) RandNum = 0;
            MoveTo = WayPoints[RandNum].position;
            yield return new WaitForSeconds(TimeMovement);
            RepetitiveNumber = RandNum;
        }
        
    }
}
