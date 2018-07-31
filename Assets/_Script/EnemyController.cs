﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D enemyRigidBody;
	private Transform player;
	public float m_Speed;
	public bool attack = false;

	//standardising Script
	public string attackAnimationString;
	public string movementAnimationString;
	public bool goingLeft,cameIntoContactWithPlayer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		enemyRigidBody = GetComponent<Rigidbody2D>();
		if(!goingLeft)
			Flip();
	}
	
	// Update is called once per frame
	void Update () {
		/*player = PlayerManager.instance.transform;
		if(cameIntoContactWithPlayer){//Chase player after coming into contact with him
			float distance = player.position.x-transform.position.x;
			print(distance);
		}*/
		//print("Is Player facing right?: "+playerFacingRight);
	}

	void FixedUpdate(){
		//Move to Main Player
		if(!attack){
			print("Finding the Player");
			animator.SetTrigger(movementAnimationString);
			SetMovementSpeed(m_Speed);
			animator.SetBool("isAttacking",attack);
		}else{//Enemy is Next to Player and should now attack
			SetMovementSpeed(0.0f);
			animator.SetTrigger(attackAnimationString);
		}
	}

	void OnCollisionStay2D(Collision2D other){//Enemy comes into contact with Player
		//print("Collisions are Going on");
		if(other.gameObject.tag =="Player"){
			cameIntoContactWithPlayer=true;
			//Debug.Log("Hit the Player");
			attack=true;
			animator.SetBool("isAttacking",attack);
		}
	}

	void OnCollisionExit2D(Collision2D other){//Enemy is not in contact with Player
		//print("Collisions has been lost");
		if(other.gameObject.tag== "Player"){
			attack=false;
			Debug.Log("Found the Player");
			animator.SetBool("isAttacking",attack);
		}
	}

	void SetMovementSpeed(float speed){
		Vector2 enemyVol = enemyRigidBody.velocity;
		enemyVol.x =speed;
		//print(speed);
		if(goingLeft){
			enemyRigidBody.velocity = -enemyVol;
		}else{
			enemyRigidBody.velocity = enemyVol;
		}
	}

	private void Flip()
	{
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
