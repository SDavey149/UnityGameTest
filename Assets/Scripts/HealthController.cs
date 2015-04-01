using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int health;

	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (gameObject);

	}

	public void RemoveHealth(int damage) {
		health -= damage;
	}

}
