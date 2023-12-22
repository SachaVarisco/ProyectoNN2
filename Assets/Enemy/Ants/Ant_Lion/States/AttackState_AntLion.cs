using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_AntLion : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Patroll")]
    private PatrollState_AntLion Patroll;
    private float Recoil;

    [Header("Movement")]
    [SerializeField] private float Speed;
    private GameObject Player;

    [Header("Attack")]
    private bool Assault = false;


    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Patroll = GetComponent<PatrollState_AntLion>();
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnEnable()
    {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(Wait2());
        //ChangeAttack();

    }
    void Update()
    {
        Debug.Log("primero yo");

        if(Patroll.LookLeft){

            Recoil = 2f;

        }else{

            Recoil = -2f;
        }

        if(Assault){

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), Speed * Time.deltaTime);
        }
        
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.1f);

        //carga el ataque (va para atras)
        transform.position = new Vector2(transform.position.x + (Recoil), transform.position.y);

        yield return new WaitForSeconds(0.5f);

        Assault = true;

        yield return new WaitForSeconds(1f);

        Assault = false;
        StateMach.ActivateState(StateMach.stateArray[0]);
    }

}