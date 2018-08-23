using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	private Animator animator;
	public BoxCollider2D weapon;
	public GameObject playerLevelUpParticles;

	//Health
	[SerializeField]
	float currentHealth;
	public float Health{
		get{ return currentHealth;}
		set {currentHealth = value;}
	}
	//Max Health
	[SerializeField]
	float maxHealth=100;
	public float MaxHealth{
		get{ return maxHealth;}
		set {maxHealth = value;}
	}

	//Strength
	[SerializeField]
	float strength=10;
	public float Strength{
		get{ return strength;}
		set {strength = value;}
	}

	//Defense
	[SerializeField]
	float defense =1;
	public float Defense{
		get{ return defense;}
		set {defense = value;}
	}

	//Exp
	float exp;
	public float Exp{
		get{ return exp;}
		private set {exp = value;}
	}

	//MaxExp
	float maxExp=100f;
	public float MaxExp{
		get{ return maxExp;}
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
		playerLevelUpParticles.SetActive(false);
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

	public void ApplyDamage(float dmg){
		if(!weapon.enabled){//Only Play Hurt Animation when Player is not attackingss
			animator.Play("Hurt");
		}
		dmg -= this.Defense;
		dmg = Mathf.Clamp(dmg,1,float.MaxValue);
		//Apply Damage to Health
		AffectHealth(-dmg);
		Debug.Log("Player Health is "+ this.Health);
		if(currentHealth <=0)
			Die();
	}

	void LevelUP(){
		StartCoroutine("PlayParticleLevelUpSystem");
		this.Level +=1;
		this.Defense +=1;
		this.Strength+=1;
		this.maxHealth +=10;
		this.currentHealth = maxHealth;//Reset Health Upon Level UP!!
		Debug.Log("Level Up");
	}

	float Attack(){
		Debug.Log("Player has attacked for " + this.Strength +" damage");
		return this.Strength;
	}

	void AffectHealth(float value){
		//Apply positive or Negative Value to Health
		currentHealth +=value;
		currentHealth = Mathf.Clamp(currentHealth,0f,maxHealth);
		// 90 Hp Heal=20
	}

	void ApplyExp(float value){
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

	IEnumerator PlayParticleLevelUpSystem(){
		playerLevelUpParticles.SetActive(true);
		yield return new  WaitForSeconds(1.0f);
		playerLevelUpParticles.SetActive(false);
	}

	//Controlled through Animation Events
	public void IsWeaponActive(int value){
		if(value ==1){
			weapon.enabled=true;
		}else{
			weapon.enabled=false;
		}
	}

	public void ApplyLevel(int pastLevel){
		for(int i=0;i<level-pastLevel;i++){
			Debug.Log("Leveling Up Now");
			this.Level +=1;
			this.Defense +=1;
			this.Strength+=1;
			this.maxHealth +=10;
			this.currentHealth = maxHealth;//Reset Health Upon Level UP!!
			Debug.Log("Level Up");

			//Player is Level =5
			//During Buff -> Players Gains 2 levels
			//Current Level 7
			//Past Level 5
			//Default Level up System for 2 levels
		}
	}

}
