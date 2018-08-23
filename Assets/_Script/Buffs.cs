using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buffs : MonoBehaviour {

	public int selectedBuff123;
	public float buffTimer=10f;
	public GameObject buffTextDisplay;
	private int playerPastLevel;
	private IEnumerator coroutine;

	void Start(){
		print("Buff Timer: "+buffTimer);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Player"){
			this.DisablePotionDisplay();//Don't show potion anymore
			playerPastLevel = collider.gameObject.GetComponent<PlayerStats>().Level;
			if(selectedBuff123==1){
					print("Strength Buff Selected");
					coroutine= ApplyStrengthBuff(collider.gameObject);
			}else if(selectedBuff123==2){
					print("Defense Buff Selected");
					coroutine=ApplyDefenseBuff(collider.gameObject);
			}else{
					print("Max Health Buff Selected");
					coroutine=ApplyHealthBuff(collider.gameObject);
			}
				buffTextDisplay.SetActive(true);
				StartCoroutine(coroutine);
			}
	}

	IEnumerator ApplyHealthBuff(GameObject player){
		float returnMaxHealth = player.GetComponent<PlayerStats>().MaxHealth;
		player.GetComponent<PlayerStats>().MaxHealth+=50f;
		player.GetComponent<PlayerStats>().Health =player.GetComponent<PlayerStats>().MaxHealth;
		yield return new WaitForSeconds(buffTimer);
		print("Buff Timer: "+buffTimer);
		player.GetComponent<PlayerStats>().MaxHealth=returnMaxHealth;
		AdjustLevelsforRemovedBuffs(player);
		buffTextDisplay.SetActive(false);
		Destroy(gameObject);
	}

	IEnumerator ApplyStrengthBuff(GameObject player){
		float returnStrength =player.GetComponent<PlayerStats>().Strength;
		player.GetComponent<PlayerStats>().Strength+=10f;
		print("Player Buff Strength: "+player.GetComponent<PlayerStats>().Strength);
		print("Buff Timer: "+buffTimer);
		yield return new WaitForSeconds(buffTimer);
		player.GetComponent<PlayerStats>().Strength=returnStrength;
		print("Player UnBuff Strength: "+player.GetComponent<PlayerStats>().Strength);
		AdjustLevelsforRemovedBuffs(player);
		buffTextDisplay.SetActive(false);
		//Destroy(gameObject);
	}

	IEnumerator ApplyDefenseBuff(GameObject player){
		float returnDefense =player.GetComponent<PlayerStats>().Defense;
		player.GetComponent<PlayerStats>().Defense+=10f;
		yield return new WaitForSeconds(buffTimer);
		player.GetComponent<PlayerStats>().Defense =returnDefense;
		AdjustLevelsforRemovedBuffs(player);
		buffTextDisplay.SetActive(false);
		Destroy(gameObject);
	}

	void AdjustLevelsforRemovedBuffs(GameObject player){
		if(playerPastLevel<player.GetComponent<PlayerStats>().Level){//Any levels gained during buffs will remain after buff is finished
			player.GetComponent<PlayerStats>().ApplyLevel(playerPastLevel);
		}
	}
		
	void DisablePotionDisplay(){
		this.GetComponent<SpriteRenderer>().enabled = false;
		this.GetComponent<Animator>().enabled =false;
		this.GetComponent<BoxCollider2D>().enabled =false;
	}


}
