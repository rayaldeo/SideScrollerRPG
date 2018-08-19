using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUpUI : MonoBehaviour {

	
	public PlayerStats player;
	public Image expFillImage;
	public Text levelText;

	private float expAmount;

	
	// Update is called once per frame
	void Update () {
		expAmount = player.Exp;
		expFillImage.fillAmount = expAmount/player.MaxExp;
		print(expAmount/player.MaxExp);
		levelText.text =player.Level.ToString();
	}
}
