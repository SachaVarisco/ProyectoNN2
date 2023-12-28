using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecution_AntLion : MonoBehaviour
{

    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Player")]
    private GameObject Player;

     [Header("Persecution")]
     [SerializeField] private float MinDistance;
    [SerializeField] private float Speed;

    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y) , Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Player.transform.position) > MinDistance)
        {
            StateMach.ActivateState(StateMach.stateArray[0]);
        }
    }
}
