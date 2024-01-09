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

    [Header ("BallBug")]
    public float floorTime = 0;
    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private GameObject Bug;
    private CircleCollider2D CircleCollider;
    private float CurrentTime;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Boss = GameObject.FindWithTag("Boss").transform;
        LifePlayer = Player.GetComponent<PlayerUtils>();
        CircleCollider = GetComponent<CircleCollider2D>();
        Objective = Player.transform;
        MaxHigh = 5;
        Launch();
    }
    private void Update(){
        if (OnTheFloor())
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime <= 0)
            {
                SpawnBug();
            }
        }else
        {
            CurrentTime = floorTime;
        }
    }
    
    private void Launch(){
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
    private bool OnTheFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(CircleCollider.bounds.center, new Vector2(CircleCollider.bounds.size.x, CircleCollider.bounds.size.y), 0f, Vector2.down, 0.2f, FloorMask);
        return raycastHit.collider != null;
    }
    private void SpawnBug(){
        Instantiate(Bug, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
