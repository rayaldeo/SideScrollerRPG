using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	//Register Attacks
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag =="Enemy"){//Trigger Collider has collided with an Enemy GameObject
			print("Attack has been registered");
		}
	}
}
