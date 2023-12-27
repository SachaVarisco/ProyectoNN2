using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Advisor")]
    [SerializeField] private GameObject Advisor;
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
        Advisor.transform.position = new Vector2 (transform.position.x, 1.5f);
        StartCoroutine(ChangeColor()); 
    }
    private void Start() {
        StateMach = GetComponent<StateMachine>();
    }

    IEnumerator ChangeColor(){
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Advisor.SetActive(true);
            Advisor.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            Advisor.GetComponent<SpriteRenderer>().color = Color.white;
        }
        StateMach.ActivateState(StateMach.stateArray[2]);
    }
}
