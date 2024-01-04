using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongState : MonoBehaviour
{
    private float BounceCounter;
    private float BossCounter;
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;
    
    [Header("Shoot")]
    [SerializeField] private GameObject Ball;
    [SerializeField] private Transform  BallLauncher;
    private void Start() {
        StateMach = GetComponent<StateMachine>();
    }
    private void OnEnable() {
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.red;
        if (BossCounter == 0)
        {
            Ball.GetComponent<BossBall>().speed = 0;
        }else if (BossCounter == 1)
        {
            Ball.GetComponent<BossBall>().speed = 3;
        }else if (BossCounter == 2)
        {
            Ball.GetComponent<BossBall>().speed = 5;
        }
        Instantiate(Ball, BallLauncher.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ball")
        {
            BounceCounter++;
            Debug.Log(BounceCounter);
            if (BounceCounter >= 3)
            {
                BossCounter++;
                Debug.Log(BossCounter);
                BounceCounter = 0;
                StateMach.ActivateState(StateMach.stateArray[2]);
                Destroy(other.gameObject);
            }
        }
    }
}
