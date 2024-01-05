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
    [SerializeField] private bool LookLeft = true;

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
    private float VelocityX;
    private Vector3 PrevPosition;
    private Vector3 MoveTo;
    private int RandNum;
    


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

    private void FixedUpdate() 
    {
        
        CalcSpeed();
        if (VelocityX > 0 && LookLeft) 
        {
            RotateX();
        }
        if (VelocityX < 0 && !LookLeft)
        {
            RotateX();
        }
    }
    private float CalcSpeed()
    {
        Vector3 currentPosition = transform.position;
        float deltaTime = Time.deltaTime;

        VelocityX = (currentPosition.x - PrevPosition.x) / deltaTime;

        PrevPosition = currentPosition;

        return VelocityX;
    }

    private void RotateX()
    {
        LookLeft = !LookLeft;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    IEnumerator Movement(){

        while (true)
        {
            RandNum = Random.Range(0,WayPoints.Length);
            MoveTo = WayPoints[RandNum].position;
            yield return new WaitForSeconds(TimeMovement);
        }
        
    }
}
