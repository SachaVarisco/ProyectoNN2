using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeState : MonoBehaviour
{
    [Header("StateMachine")]
    private StateMachine StateMach;
    [SerializeField] private GameObject StateIndicator;

    [Header("Move")]
    [SerializeField] private float Speed;
    private Rigidbody2D rb2d;
    private Vector2 Direction = Vector2.right;

    private void Start()
    {
        StateMach = GetComponent<StateMachine>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() {
        Direction *= Vector2.left;
        StateIndicator.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement = Direction * Speed;
        rb2d.AddForce(movement, ForceMode2D.Impulse);

    }
}
