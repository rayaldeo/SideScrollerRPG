using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buffs : MonoBehaviour {

	public int selectedBuff123;
	public float buffTimer =10f;
	public GameObject buffTextDisplay;
	private int playerPastLevel;
	private IEnumerator couroutine;

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag =="Player"){
			this.DisablePotionDisplay();//Don't Show Potion Anymore
			playerPastLevel = collider.gameObject.GetComponent<PlayerStats>().Level;
			if(selectedBuff123==1){
				print("Strength Buff Selected");
				couroutine = ApplyStrengthBuff(collider.gameObject);
			}else if(selectedBuff123==2){
				print("Defense Buff Selected");
				couroutine = ApplyDefenseBuff(collider.gameObject);
			}else{
				print("Max Health Buff Selected");
				couroutine = ApplyMaxHealthBuff(collider.gameObject);
			}
			buffTextDisplay.SetActive(true);
			StartCoroutine(couroutine);
		}
	}

	IEnumerator ApplyMaxHealthBuff(GameObject player){
		float returnMaxHealth = player.GetComponent<PlayerStats>().MaxHealth;
		print("Return Max Health: "+returnMaxHealth);
		player.GetComponent<PlayerStats>().MaxHealth+=50f;
		player.GetComponent<PlayerStats>().Health = player.GetComponent<PlayerStats>().MaxHealth;
		yield return new WaitForSeconds(buffTimer);
		player.GetComponent<PlayerStats>().MaxHealth= returnMaxHealth;
		AdjustLevelsForRemovedBuffs(player);
		buffTextDisplay.SetActive(false);
		Destroy(gameObject);
	}

	IEnumerator ApplyStrengthBuff(GameObject player){
		float returnStrength =player.GetComponent<PlayerStats>().Strength;
		player.GetComponent<PlayerStats>().Strength+=10f;
		yield return new WaitForSeconds(buffTimer);
		player.GetComponent<PlayerStats>().Strength = returnStrength;
		AdjustLevelsForRemovedBuffs(player);
		buffTextDisplay.SetActive(false);
		Destroy(gameObject);
	}

	IEnumerator ApplyDefenseBuff(GameObject player){
		float returnDefense =player.GetComponent<PlayerStats>().Defense;
		player.GetComponent<PlayerStats>().Defense+=10;
		yield return new WaitForSecondsRealtime(buffTimer);
		player.GetComponent<PlayerStats>().Defense = returnDefense;
		AdjustLevelsForRemovedBuffs(player);
		buffTextDisplay.SetActive(false);
		Destroy(gameObject);
	}

	void AdjustLevelsForRemovedBuffs(GameObject player){
		if(playerPastLevel< player.GetComponent<PlayerStats>().Level){
			player.GetComponent<PlayerStats>().ApplyLevel(playerPastLevel);
		}
	}


	void DisablePotionDisplay(){
		this.GetComponent<SpriteRenderer>().enabled=false;
		this.GetComponent<Animator>().enabled =false;
		this.GetComponent<BoxCollider2D>().enabled =false;
	}

}
