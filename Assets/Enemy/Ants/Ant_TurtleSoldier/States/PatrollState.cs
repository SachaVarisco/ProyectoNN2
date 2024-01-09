using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Raycast")]

    public bool booler;
    public float timer;
    public Quaternion rotation;
    public RaycastHit2D rchit;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask Layer;
    private Vector2 rcOrientation;

    [Header("Movement")]
    [SerializeField] private Transform[] WayPoints;
    [SerializeField]private float Speed;
    [SerializeField] private float MinDistance;
    [SerializeField] private bool LookLeft = true;
    private int RandNum;
    private float VelocityX;
    private Vector3 PrevPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        rotation = new Quaternion();
        RandNum = Random.Range(0,WayPoints.Length);
        rcOrientation = Vector2.left;

    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[RandNum].position, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoints[RandNum].position) < MinDistance)
        {
            RandNum = Random.Range(0,WayPoints.Length);
        } 

        rchit = Physics2D.Raycast(gameObject.transform.position, rcOrientation, distance, Layer);
        Debug.DrawRay(gameObject.transform.position, rcOrientation * distance, Color.green);
        if (rchit.collider != null && rchit.collider.CompareTag("Player"))
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
        rcOrientation = rcOrientation * new Vector2(-1,0);
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
