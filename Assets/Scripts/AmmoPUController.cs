using UnityEngine;
using System.Collections;

public class AmmoPUController : MonoBehaviour {

	PlayerController player;
	int ammoValue;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		ammoValue = Random.Range (20, 40);
	}
	
	void OnTriggerEnter(Collider c) {
		player.AddAmmo (ammoValue);
		Destroy (gameObject);
	}
}
