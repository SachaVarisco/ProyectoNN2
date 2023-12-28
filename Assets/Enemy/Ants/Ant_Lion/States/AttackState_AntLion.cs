using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_AntLion : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    // [Header("Patroll")]
    // private PatrollState_AntLion Patroll;
    // private float Recoil;

    [Header("Movement")]
    [SerializeField] private float Speed;
    private GameObject Player;

    Vector2 target;

    private void OnEnable()
    {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(Wait2());

    }

    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        //embestida
        transform.position = Vector2.MoveTowards(transform.position, target , Speed * Time.deltaTime);


    }
 
    IEnumerator Wait2()
    {
        //para que reconozca la posicion del Player
        yield return new WaitForSeconds(0.1f);
        
        target = new Vector2(Player.transform.position.x,transform.position.y);

        yield return new WaitForSeconds(1f);

        StateMach.ActivateState(StateMach.stateArray[3]);
    }


}