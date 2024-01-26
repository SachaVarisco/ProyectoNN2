using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState_FireBlack : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    
    [Header("Player")]
    private Transform Player;

    [Header("Ant")]
    private Transform AntTransform;
    [SerializeField]private float Speed;

    [Header("WayPoints")]
    [SerializeField] private Transform WayPointsBase;
    [SerializeField] private Transform[] WayPoints;


    [Header("Distance")]
    [SerializeField] private float AttackDistance;
    private float distance;

    [Header("RayCast")]
    [SerializeField] private float distanceRaycast;
    public LayerMask targetLayer;

    private Vector3 MoveTo;
    private int RandNum;

    private bool changeState;
    


    void OnEnable()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindWithTag("Player").transform;
        AntTransform = GetComponent<Transform>();
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        
        changeState = true;

        WayPointsBase.position = this.gameObject.transform.position;
        RandNum = Random.Range(0,WayPoints.Length);
        MoveTo = WayPoints[RandNum].position;
        
        StartCoroutine(ChangeState());
        
    }
    

    
    void Update()
    {
        Distance();

        RaycastDown();
        RaycastUp();
        RaycastRight();
        RaycastLeft();
    }

    private void RaycastDown()
    {
        //Raycast
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, distanceRaycast, targetLayer);

        //Movimiento de enemigo
        if (hit.collider != null)
        {   
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, WayPoints[0].position, Speed * Time.deltaTime);
        } else {
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, MoveTo, Speed * Time.deltaTime);
        }

        Debug.DrawRay(raycastOrigin, raycastDirection * distanceRaycast, Color.red);
    }

    private void RaycastUp()
    {
        //Raycast
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.up;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, distanceRaycast, targetLayer);

        //Movimiento de enemigo
        if (hit.collider != null)
        {   
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, WayPoints[2].position, Speed * Time.deltaTime);
        } else {
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, MoveTo, Speed * Time.deltaTime);
        }

        Debug.DrawRay(raycastOrigin, raycastDirection * distanceRaycast, Color.red);
    }

    private void RaycastRight()
    {
        //Raycast
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, distanceRaycast, targetLayer);

        //Movimiento de enemigo
        if (hit.collider != null)
        {   
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, WayPoints[3].position, Speed * Time.deltaTime);
        } else {
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, MoveTo, Speed * Time.deltaTime);
        }

        Debug.DrawRay(raycastOrigin, raycastDirection * distanceRaycast, Color.red);
    }

    private void RaycastLeft()
    {
        //Raycast
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, distanceRaycast, targetLayer);

        //Movimiento de enemigo
        if (hit.collider != null)
        {   
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, WayPoints[1].position, Speed * Time.deltaTime);
        } else {
            AntTransform.position = Vector3.MoveTowards(AntTransform.position, MoveTo, Speed * Time.deltaTime);
        }

        Debug.DrawRay(raycastOrigin, raycastDirection * distanceRaycast, Color.red);
    }

    private void Distance(){

        if (Player != null && AntTransform != null)
        {
            // Calcula la distancia entre el player y la hormiga.
            distance = Vector3.Distance(Player.position, AntTransform.position);

        }

        if(distance > AttackDistance) 
        {
            StateMach.ActivateState(StateMach.stateArray[1]);
            changeState = false;
        }
    }

    IEnumerator ChangeState(){

        yield return new WaitForSeconds(2.5f);
        if(changeState) StateMach.ActivateState(StateMach.stateArray[2]);
    }
}
