using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    /*public MonoBehaviour startState;
    public MonoBehaviour patrollState;
    public MonoBehaviour attackState;*/

    public MonoBehaviour[] stateArray;

    private MonoBehaviour ActualState;


    // Start is called before the first frame update
    private void Start()
    {
        ActivateState(stateArray[0]);
    }

    // Update is called once per frame 

    public void ActivateState(MonoBehaviour newState){
        if (ActualState != null)
        {
            ActualState.enabled = false; 
        }
        ActualState = newState;
        ActualState.enabled = true;
    }
}
