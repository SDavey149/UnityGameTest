using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public float speed;
	public Vector3 target;
	public int inflictedDamage;

	// Use this for initialization
	void Start () {
		transform.Rotate (0, 0, 90); //bullet right way up
		rigidbody.velocity = (target - transform.position).normalized * speed; //work out direction to target
	}


	void OnCollisionEnter(Collision c) {
		HealthController health = c.collider.GetComponent<HealthController> ();
		if (health != null) {
			health.RemoveHealth(inflictedDamage);
		}
		Destroy (gameObject); //destroy bullet when collision takes place
	}

}
