using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int health;
	public int additionalScoreOnDeath;
	PlayerController player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Die ();

	}

	public void RemoveHealth(int damage) {
		health -= damage;
	}

	private void Die() {
		player.AddScore (additionalScoreOnDeath);
		Destroy (gameObject);

	}

}
