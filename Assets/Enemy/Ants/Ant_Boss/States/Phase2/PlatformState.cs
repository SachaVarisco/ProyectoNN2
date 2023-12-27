using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Impulse")]
    public bool canPush;
    [SerializeField] private float Speed;

    [Header("Advisor")]
    [SerializeField] private GameObject Advisor;
    private void OnEnable() {
        Advisor.SetActive(false);
        canPush = true;
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(ChangeState());
    }
    private void Start() {
        StateMach = GetComponent<StateMachine>();
    }
    private void Update() {
        float step = Speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 1.8f), step);
    }
    IEnumerator ChangeState(){
        yield return new WaitForSeconds(0.6f);
        canPush = false;
        yield return new WaitForSeconds(2f);
        StateMach.ActivateState(StateMach.stateArray[3]);
    }
}
