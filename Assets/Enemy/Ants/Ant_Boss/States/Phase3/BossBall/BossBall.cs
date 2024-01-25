using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBall : MonoBehaviour
{
    [SerializeField] private  Transform Objective;
    //[SerializeField] private GameObject Ball;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform Boss;
    private float MaxHigh = 5;
    private float Gravity = -9.8f;

    [Header ("Damage")]
    [SerializeField] private float DamageBossBall;

    private PlayerUtils LifePlayer;


    private void Start()
    {
        LifePlayer = Player.GetComponent<PlayerUtils>();
        Objective = Player.transform;
        Launch();
    }
    
    void Launch(){
        Rigidbody2D BallRb = GetComponent<Rigidbody2D>();
        Physics.gravity = Vector3.up * Gravity;
   
        //BallRb.gravityScale = 1;

        BallRb.velocity = CalcInitialVelocity();
    }

    private Vector2 CalcInitialVelocity(){
        Vector2 P = Objective.position - gameObject.transform.position;

        float VelocityY, VelocityX /*, VelocityZ*/;

        VelocityY = Mathf.Sqrt(-2 * Gravity * MaxHigh);

        VelocityX = P.x / ((-VelocityY / Gravity) + Mathf.Sqrt(2 * (P.y - MaxHigh) / Gravity));
        //VelocityZ = 0;

        return new Vector2(VelocityX, VelocityY/*, VelocityZ*/);
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

        // if (other.gameObject.layer == 6) //Layer "Platforms"
        // {
            
            
        // }
    }
    public void ChangeObjective(){
        Objective = Boss;
        Launch();
    }
}
