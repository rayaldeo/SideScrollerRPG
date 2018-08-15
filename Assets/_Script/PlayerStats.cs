using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	private Animator animator;
	public BoxCollider2D weapon;

	//Health
	[SerializeField]
	float currentHealth;
	public float Health{
		get{ return currentHealth;}
		private set {currentHealth = value;}
	}
	//Max Health
	[SerializeField]
	float maxHealth=100;
	public float MaxHealth{
		get{ return maxHealth;}
	}

	//Strength
	[SerializeField]
	int strength=10;
	public int Strength{
		get{ return strength;}
		private set {strength = value;}
	}

	//Defense
	[SerializeField]
	int defense =1;
	public int Defense{
		get{ return defense;}
		private set {defense = value;}
	}

	//Exp
	float exp,maxExp=100f;
	public float Exp{
		get{ return exp;}
		private set {exp = value;}
	}

	//Level
	int level =1;
	public int Level{
		get{ return level;}
		private set {level = value;}
	}

	void Awake(){
		currentHealth =maxHealth;
	}

	// Use this for initialization
	void Start () {
		IsWeaponActive(0);
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("h")){
			ApplyDamage(12);
		}

		if(Input.GetKeyDown("e")){
			ApplyExp(12);
		}
	}

	void Die(){
		Debug.Log("Player has died!");
	}

	void ApplyDamage(float dmg){
		animator.Play("Hurt");
		dmg -= this.Defense;
		dmg = Mathf.Clamp(dmg,1,float.MaxValue);
		//Apply Damage to Health
		AffectHealth(-dmg);
		Debug.Log("Player Health is "+ this.Health);
		if(currentHealth <=0)
			Die();
	}

	void LevelUP(){
		this.Level +=1;
		this.Defense +=1;
		this.Strength+=1;
		this.maxHealth +=10;
		this.currentHealth = maxHealth;//Reset Health Upon Level UP!!
		Debug.Log("Level Up");
	}

	int Attack(){
		Debug.Log("Player has attacked for " + this.Strength +" damage");
		return this.Strength;
	}

	void AffectHealth(float value){
		//Apply positive or Negative Value to Health
		currentHealth +=value;
		currentHealth = Mathf.Clamp(currentHealth,0f,maxHealth);
		// 90 Hp Heal=20
	}

	void ApplyExp(int value){
		exp+=value;
		if(exp >= maxExp){
			LevelUP();
			exp =exp-maxExp;
			//MaxExp =100
			//Current Exp =95
			//Gain 10 exp
			//Level Up with Current Exp at 5
		}
		print("Current Level: " + this.Level + "Current Exp: "+ this.Exp);
	}

	//Controlled through Animation Events
	public void IsWeaponActive(int value){
		if(value ==1){
			weapon.enabled=true;
		}else{
			weapon.enabled=false;
		}
	}

}
