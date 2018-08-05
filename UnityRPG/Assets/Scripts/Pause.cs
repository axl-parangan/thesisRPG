﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour {

	private PlayerController pc;
	public GameObject panel;
	public Text pauseText;

	void Start () {
		pc = FindObjectOfType<PlayerController> ();
	}


	public void pause () {
		if (Time.timeScale == 1) {
			panel.SetActive (true);
			Time.timeScale = 0;
			pc.canMove = false;
			pauseText.text = "Resume";
		} 
		else {

			Time.timeScale = 1;
			pc.canMove = true;
			panel.SetActive (false);
			pauseText.text = "Pause";
		}
	}
}