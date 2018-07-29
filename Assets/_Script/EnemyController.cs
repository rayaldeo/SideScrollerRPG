using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D enemyRigidBody;
	public float m_Speed;
	public bool attack = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		enemyRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		//Move to Main Player
		if(!attack){
			animator.SetTrigger("run");
			SetMovementSpeed(m_Speed);
			animator.SetBool("isAttacking",attack);
		}else{//Enemy is Next to Player and should now attack
			SetMovementSpeed(0.0f);
			animator.SetTrigger("skill_1");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag =="Player"){
			Debug.Log("Hit the Player");
			attack=true;
			animator.SetBool("isAttacking",attack);
		}
	}

	void SetMovementSpeed(float speed){
		Vector2 enemyVol = enemyRigidBody.velocity;
		enemyVol.x =speed;
		print(speed);
		enemyRigidBody.velocity = -enemyVol;
	}
}
