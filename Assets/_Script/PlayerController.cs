using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    // Update is called once per frame
    void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;
       
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
	}

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
