using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    // Start is called before the first frame update
    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        StartCoroutine(Wait());
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Update is called once per frame
    IEnumerator Wait(){
        yield return new WaitForSeconds(1f);
        StateMach.ActivateState(StateMach.stateArray[1]);
    }
}
