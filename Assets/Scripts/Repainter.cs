using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Repainter : MonoBehaviour {
	
	public Text scoreText;
	public Text ammoText;
	public Text healthText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RepaintScore(int score) {
		scoreText.text = "Score: " + score;
	}

	public void RepaintAmmo(int ammo) {
		ammoText.text = "Ammo: " + ammo;
	}

	public void RepaintHealth(int health) {
		healthText.text = "Health: " + health;
	}
}
