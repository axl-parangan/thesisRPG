﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public bool invincible = false;

	// Use this for initialization
	void Start () {
		if (SaveGame.Exists("currenthp")) {
			Load ();
		} 
		else {
			playerCurrentHealth = playerMaxHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive (false);

		}
	}

	public void Save(){

		SaveGame.Save<int>("currenthp", playerCurrentHealth);
		SaveGame.Save<int>("maxhp", playerMaxHealth);

	}

	public void Load(){

		playerCurrentHealth = SaveGame.Load<int>("currenthp");
		playerMaxHealth = SaveGame.Load<int>("maxhp");
	}

	public void HurtPlayer(int damage) {
		if (!invincible) {
			
			playerCurrentHealth -= damage;

			invincible = true;
			Invoke ("resetInvulnerability", 2);
		}
		StartCoroutine ("HurtColor");
	}

	void resetInvulnerability(){
		invincible = false;
	}

	IEnumerator HurtColor() {
		for (int i = 0; i < 8; i++) {
			GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.3f); //Red, Green, Blue, Alpha/Transparency
			yield return new WaitForSeconds (.1f);
			GetComponent<SpriteRenderer>().color = Color.white; //White is the default "color" for the sprite, if you're curious.
			yield return new WaitForSeconds (.1f);
		}
	} 

	public void SetMaxHealth(){
		playerCurrentHealth = playerMaxHealth;

	}

}
