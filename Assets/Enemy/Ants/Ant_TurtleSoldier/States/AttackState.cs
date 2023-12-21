using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Movement")]
    [SerializeField]private float Speed;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable() {
        StartCoroutine(Wait());
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), Speed * Time.deltaTime);
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        StateMach.ActivateState(StateMach.stateArray[0]);
    }

}