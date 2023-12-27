using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnState : MonoBehaviour
{    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Impulse")]
    [SerializeField] private float Speed;
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        StartCoroutine(ChangeState());
    }
    private void Start() {
        StateMach = GetComponent<StateMachine>();
    }
    private void Update() {
        float step = Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -4.4f), step);
    }
    IEnumerator ChangeState(){
        yield return new WaitForSeconds(3f);
        StateMach.ActivateState(StateMach.stateArray[0]);
    }
}
