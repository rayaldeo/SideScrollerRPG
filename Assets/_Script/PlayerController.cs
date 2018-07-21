using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove, verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump,crouch = false;

    // Update is called once per frame
    void Update () {
    	horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;
    	verticalMove = Input.GetAxisRaw("Vertical");

    	if(verticalMove == -1|| horizontalMove !=0 && verticalMove==-1){
			crouch=true;
			animator.SetBool("CrouchBool",crouch);
			if(horizontalMove !=0){
				animator.SetBool("CrouchDashBool",crouch);
			}
    	}else{//Once Crouch is Finish Stop all appropriate Animations
			crouch=false;
			animator.SetBool("CrouchBool",crouch);
			animator.SetBool("CrouchDashBool",crouch);
    	}

		if (Input.GetButtonDown("Jump") && controller.m_Grounded && !crouch)
        {
            jump = true;
            animator.SetFloat("RunFloat", Mathf.Abs(0.0f));//Stop Running Animation
            animator.SetTrigger("JumpTrigger");
        }
        else//Handling Running/horizontalMove
        {
		  animator.SetFloat("RunFloat", Mathf.Abs(horizontalMove));
        }

        //Attack Animations
		if(!crouch){
			if(controller.m_Grounded){//Is Player Grounded
					if(Input.GetButtonDown("Fire1")){
						animator.Play("AttackOne");
			        }

		        if(Input.GetButtonDown("Fire2")){
					animator.Play("AttackTwo");
			       }
	        }else{
	        	if(Input.GetButtonDown("Fire1")){//Jump Attack
	        		animator.Play("JumpAttack");
	        	}
	        }
        }
	}

    void FixedUpdate()
    {
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	    jump = false;
    }
}
