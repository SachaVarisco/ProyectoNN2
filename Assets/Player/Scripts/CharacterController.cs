using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Stats")]

    private PlayerUtils utils;

    [Header("Movement")]

    private bool LookingRight = true;
    private Rigidbody2D RigidBody;
    private Looking Looking;


    [Header("Jump")]

    public float jumpForce;
    public LayerMask floorMask;
    private BoxCollider2D BoxCollider;

    [Header("Bounce Hit")]
    [SerializeField] private Vector2 BouncePlayer;

    private Animator animator;
    
    void Start()
    {
        Looking = GetComponent<Looking>();
        RigidBody = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        utils = GetComponent<PlayerUtils>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (utils.moveIsTrue)
        {
            CharacterMovement();
            Jump();
        }
        
    }


    private void CharacterMovement()
    {
        //Movimiiento de personaje
        float horizontalMovement = Input.GetAxis("Horizontal");
        RigidBody.velocity = new Vector2(horizontalMovement * utils.speed, RigidBody.velocity.y);

        BodyOrientation(horizontalMovement);
    }

    private void BodyOrientation(float horizontalMovement)
    {
        //Cambio de orientacion del personaje

        if((LookingRight == true && horizontalMovement < 0) || (LookingRight == false && horizontalMovement > 0))
        {
            LookingRight = !LookingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180 , 0);
            //transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && OnTheFloor())
        {
            RigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(OnTheFloor())
        {
            utils.onTheFloor = true;
        } else {
            utils.onTheFloor = false;
        }
    }

    // private void Animations()
    // {   
    //     //Movimiento correr
    //     if (Input.GetKey(KeyCode.A) && OnTheFloor() || Input.GetKey(KeyCode.D) && OnTheFloor())
    //     {
    //         animator.SetBool("isRunning", true);

    //     } else {

    //         animator.SetBool("isRunning", false);
    //     }

    //     //Salto
    //     if(!OnTheFloor())
    //     {
    //         animator.SetBool("isJumping", true);

    //     } else {

    //         animator.SetBool("isJumping", false);
    //     }

    //     animator.SetFloat("MoveY", RigidBody.velocity.y);
        
    // }

    public bool OnTheFloor()
    {
        //Evitar salto multiple
        //
        //Cuando vuelve a tocar el Layer de "Platforms", puede volver a saltar.

        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider.bounds.center, new Vector2(BoxCollider.bounds.size.x, BoxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, floorMask);
        return raycastHit.collider != null;
    }

    public void Bounce(Vector2 pointHit)
    {
        RigidBody.velocity = new Vector2(-BouncePlayer.x * pointHit.x, BouncePlayer.y);
    }


}
