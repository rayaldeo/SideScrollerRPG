using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	private Animator animator;
	public string hurtAnimationString,deathAnimationString;

	//Health
	[SerializeField]
	int currentHealth,maxHealth=100;
	public int Health{
		get{ return currentHealth;}
		private set {currentHealth = value;}
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
	public float givingExp;
	public float Exp{
		get{ return givingExp;}
		private set {givingExp = value;}
	}

	//Level
	[SerializeField]
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
		animator = GetComponent<Animator>();
		//ApplyLevel(/*Game Level*/)
	}
	
	// Update is called once per frame
	void Update () {
	//Testing
		if(Input.GetKeyDown("o")){
			ApplyDamage(12);
		}

		if(Input.GetKeyDown("p")){
			ApplyLevel(12);
		}
	}

	void Die(){
		animator.Play(deathAnimationString);
		Debug.Log("Enemy has died and is Giving Off this much EXP: "+this.Exp);
		Collider2D[] colliders = this.GetComponents<Collider2D>();
		foreach(Collider2D collider in colliders){//this will disable all collision/Colliders on the Enemy GameObject
			collider.enabled=false;
		}
		GetComponent<EnemyController>().enabled=false;//Stop the Enemy from Follwing and attacking the Player
	}

	public void ApplyDamage(int dmg){
		animator.Play("Hurt");
		dmg -= this.Defense;
		dmg = Mathf.Clamp(dmg,1,int.MaxValue);
		//Apply Damage to Health
		AffectHealth(-dmg);
		Debug.Log("Enemy Health is "+ this.Health);
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
		Debug.Log("Enemy has attacked for " + this.Strength +" damage");
		return this.Strength;
	}

	void AffectHealth(int value){
		//Apply positive or Negative Value to Health
		currentHealth +=value;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
		// 90 Hp Heal=20
	}

	void ApplyLevel(int value){
		for(int i=0;i<value;i++){
			Debug.Log("Leveling Up Now");
			LevelUP();
		}
	}




		
}
