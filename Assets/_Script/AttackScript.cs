using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	private PlayerStats player;

	void Start(){
		player = GetComponentInParent<PlayerStats>();
		print("Player Attack Value: "+ player.Strength); 
	}

	//Register Attacks
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag =="Enemy"){//Trigger Collider has collided with an Enemy GameObject
			other.gameObject.GetComponent<EnemyStats>().ApplyDamage(player.Strength);
			//print("Attack has been registered");
		}
	}
}
