using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	float playerHealthValue;

	public Text healthValueText;
	public PlayerStats player;
	public Image healthFillImage;
	public GameObject heartIcon;


	//Use this for initialization
	void Start(){
		heartIcon.GetComponent<Animator>().enabled = false;
	}

	//Update is called once per frame
	void Update(){
		//Keep track of Current Health of the Player
		playerHealthValue = player.Health;
		healthValueText.text ="HP: "+ playerHealthValue.ToString();
		healthFillImage.fillAmount = playerHealthValue/player.MaxHealth;
		//Max Health =100
		//Current Health =50
		//10/100 =0.1
		print("Health Fill Image Value: "+ playerHealthValue/player.MaxHealth + " Player's Current Health: " +player.Health +
		" Player's Max Health: "+ player.MaxHealth);
		if(player.Health<=15){
			heartIcon.GetComponent<Animator>().enabled = true;
		}else{
			heartIcon.GetComponent<Animator>().enabled = false;
		}
	}

}

