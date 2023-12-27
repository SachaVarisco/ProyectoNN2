using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnnedState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Spikes")]
    public string WallName;
    [SerializeField] private GameObject SpikePrefab;
    [SerializeField] private Transform SpikeController1;
    [SerializeField] private Transform SpikeController2;
    
    // Start is called before the first frame update
    private void Start()
    {
        StateMach = GetComponent<StateMachine>(); 
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.magenta;
        StartCoroutine(Wait());
        if (WallName == "Wall1")
        {
            Instantiate(SpikePrefab, SpikeController1.position, Quaternion.Euler(0,0,180));
        }else if (WallName == "Wall2")
        {
            Instantiate(SpikePrefab, SpikeController2.position, Quaternion.Euler(0,0,180));
        }
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1f);
        transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        StateMach.ActivateState(StateMach.stateArray[1]);
    }
}
