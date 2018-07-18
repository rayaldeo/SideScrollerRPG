using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove, verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    // Update is called once per frame
    void Update () {
    	if(!Input.GetButtonDown("Fire1") || !Input.GetButtonDown("Fire2")){
        	horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;
        }

		if (Input.GetButtonDown("Jump") && controller.m_Grounded)
        {
            jump = true;
            animator.SetFloat("RunFloat", Mathf.Abs(0.0f));//Stop Running Animation
            animator.SetTrigger("JumpTrigger");
        }
        else
        {
		  animator.SetFloat("RunFloat", Mathf.Abs(horizontalMove));
        }

        //Attack Animations
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

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
	    jump = false;
    }
}
