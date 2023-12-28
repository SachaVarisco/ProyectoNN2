using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilState_AntLion : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Patroll")]
    private PatrollState_AntLion Patroll;
    private float Recoil;

    [Header("Movement")]
    private GameObject Player;
    [SerializeField] private float Speed;


    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Patroll = GetComponent<PatrollState_AntLion>();
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnEnable()
    {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        StartCoroutine(ChangeAttack());

    }
    void Update()
    {
        // Debug.Log("primero yo");

        // if(Patroll.LookLeft){

        //     Recoil = 2f;

        // }else{

        //     Recoil = -2f;
        // }
        
        //transform.position = new Vector2(transform.position.x + (Recoil), transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + (Recoil), transform.position.y) , Speed * Time.deltaTime);
    }

    IEnumerator ChangeAttack()
    {
        yield return new WaitForSeconds(0.1f);

        //direccion del retroceso
        if(Patroll.LookLeft){

            Recoil = 2f;

        }else{

            Recoil = -2f;
        }

        yield return new WaitForSeconds(0.7f);

        StateMach.ActivateState(StateMach.stateArray[2]);
    }

}