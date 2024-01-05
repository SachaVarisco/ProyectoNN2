using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePhase3State : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    private void Start()
    {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(1f);
        StateMach.ActivateState(StateMach.stateArray[1]);
    }
}