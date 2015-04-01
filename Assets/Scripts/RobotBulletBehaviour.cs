using UnityEngine;
using System.Collections;

public class RobotBulletBehaviour : MonoBehaviour {

	public float speed;
	
	// Use this for initialization
	void Start () {
		transform.Rotate (0, 0, 90); 
		rigidbody.velocity = transform.up * speed;
		
	}
	
	void OnCollisionEnter(Collision c) {
		Destroy (gameObject);
	}
}
