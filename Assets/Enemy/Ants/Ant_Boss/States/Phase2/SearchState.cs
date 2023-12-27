using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    private GameObject Player;
    
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.green;
        StartCoroutine(Search());
    }
    private void Start()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    IEnumerator Search(){
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector3(Player.transform.position.x, gameObject.transform.position.y, 0f);
        StateMach.ActivateState(StateMach.stateArray[1]);
    }
}
