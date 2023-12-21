using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHeadController : MonoBehaviour
{
    private StateMachine StateMach;
    private GameObject AntBody;

    private void Start() {
        AntBody = transform.parent.gameObject;
        StateMach =  transform.parent.gameObject.GetComponent<StateMachine>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Wall"){
            AntBody.GetComponent<StunnnedState>().WallName = other.gameObject.name;
            StateMach.ActivateState(StateMach.stateArray[2]);
            
        }
    }
}
