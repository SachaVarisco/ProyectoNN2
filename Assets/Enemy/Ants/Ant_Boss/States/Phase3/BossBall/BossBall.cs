using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBall : MonoBehaviour
{
    [Header ("Throw")]

    public float speed;
    private float MaxHigh;
    private  Transform Objective;
    private GameObject Player;
    private Transform Boss;

    private float Gravity = -9.8f;
    [Header ("Boss")]
    private float BossCounter;

    [Header ("Damage")]
    [SerializeField] private float DamageBossBall;
    private PlayerUtils LifePlayer;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Boss = GameObject.FindWithTag("Boss").transform;
        LifePlayer = Player.GetComponent<PlayerUtils>();
        Objective = Player.transform;
        MaxHigh = 5;
        Launch();
    }
    
    void Launch(){
        Rigidbody2D BallRb = GetComponent<Rigidbody2D>();
        Physics.gravity = Vector3.up * Gravity;
        BallRb.velocity = CalcInitialVelocity();
    }

    private Vector2 CalcInitialVelocity(){
        Vector2 P = Objective.position - transform.position;
        float VelocityY, VelocityX;
        VelocityY = Mathf.Sqrt(-2 * Gravity * MaxHigh);
        VelocityX = P.x / ((-VelocityY / Gravity) + Mathf.Sqrt(2 * (P.y - MaxHigh) / Gravity));
        if (Objective == Player.transform)
        {
            VelocityX += speed;
            //VelocityY -= speed;
        }
        return new Vector2(VelocityX , VelocityY);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Boss")
        {
            Objective = Player.transform;
            Launch();
        }
        if (other.gameObject.tag == "Player")
        {
            LifePlayer.TakeDamage(DamageBossBall);
        }
    }
    public void ChangeObjective(){
        Objective = Boss;
        Launch();
    }
    private void ChangeState(){
        Destroy(gameObject);
    }
}
