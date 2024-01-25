using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RigidBody;
    private PlayerUtils utils;
    private Looking looking;

    void Start()
    {
        animator = GetComponent<Animator>();
        RigidBody = GetComponent<Rigidbody2D>();
        utils = GetComponent<PlayerUtils>();
        looking = GetComponent<Looking>();

        utils.onTheFloor = true;
    }

    
    void Update()
    {
        Animations();
    }

    private void Animations()
    {   
        //Movimiento correr
        if (Input.GetKey(KeyCode.A) && utils.onTheFloor || Input.GetKey(KeyCode.D) && utils.onTheFloor)
        {
            animator.SetBool("isRunning", true);

        } else {

            animator.SetBool("isRunning", false);
        }

        //Salto
        if(!utils.onTheFloor)
        {
            animator.SetBool("isJumping", true);
            
        } else {

            animator.SetBool("isJumping", false);
        }

        animator.SetFloat("MoveY", RigidBody.velocity.y);


        //Ataques en suelo

        if(looking.direction == "Up")
        {
            if(Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isAttackingUp", true);
            }else{
                animator.SetBool("isAttackingUp", false);
            }

        } else {

            if(Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isAttacking", true);
            }else{
                animator.SetBool("isAttacking", false);
            }
        }


        //Ataques en aire

        if(looking.direction == "Up" && animator.GetBool("isJumping") == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isAttackingJumpUp", true);
            }else{
                animator.SetBool("isAttackingJumpUp", false);
            }

        } else if(looking.direction != "Up" && animator.GetBool("isJumping") == true){

            if(Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isAttackingJump", true);
            }else{
                animator.SetBool("isAttackingJump", false);
            }
        }
        
    }


    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.name == "Ant_BearTrap"){

            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
        }
 
    }
}
