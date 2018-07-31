﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	#region Singleton
	public static PlayerManager instance;

	void Awake(){
		instance=this;
	}
	#endregion

	public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//print("Facing Right: "+player.facingRight);
	}

}
