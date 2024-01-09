using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBug : MonoBehaviour
{
    [Header("Boss")]
    private Transform Boss;

    [Header("Move")]
    [SerializeField] private float Speed;
    private Rigidbody2D Rb2d;
    private Vector2 Direction = Vector2.right;

    private void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        Boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement = Direction * Speed;
        Rb2d.AddForce(movement);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
