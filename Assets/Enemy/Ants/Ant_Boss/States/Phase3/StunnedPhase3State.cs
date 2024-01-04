using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedPhase3State : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Stomach")]
    [SerializeField] private GameObject Stomach;

    private void Start()
    {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        Stomach.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(5f);
        Stomach.SetActive(false);
        StateMach.ActivateState(StateMach.stateArray[0]);
    }
}
