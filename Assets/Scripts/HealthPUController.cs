using UnityEngine;
using System.Collections;

public class HealthPUController : MonoBehaviour {

	PlayerController player;
	public int healthVal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	void OnTriggerEnter(Collider c) {
		player.AddHealth (healthVal);
		Debug.Log ("Added health: " + healthVal);
		Destroy (gameObject);
	}
}
