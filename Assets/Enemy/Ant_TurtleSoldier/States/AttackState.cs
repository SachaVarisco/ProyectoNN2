using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMachine;
    [Header("Movement")]
    [SerializeField]private float Speed;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<StateMachine>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable() {
        StartCoroutine(Wait());
    }
    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        StateMachine.ActivateState(StateMachine.patrollState);
    }

}
