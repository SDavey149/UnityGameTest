using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int jumpForce;

	public float lookSpeed;
	public float jumpRate;
	private float nextJump;
	private float yaw;

	private Animator anim;
	//private AnimController controller;
	
	private float yawVelocity = 0f;

	void Start() {
		anim = GetComponent<Animator> ();
		//controller = GetComponent<AnimController> ();
	}
	

	void FixedUpdate() {
		float mouseX = Input.GetAxis ("Mouse X") * lookSpeed;
		yaw = Mathf.SmoothDamp (yaw, yaw + mouseX, ref yawVelocity, 0.1f);
		transform.rotation = Quaternion.Euler (0, yaw, 0);

		float horiz = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		//Vector3 movement = new Vector3 (horiz, 0.0f, vertical);
		//movement.Normalize ();
		//rigidbody.AddRelativeForce(movement * speed, ForceMode.VelocityChange);
		anim.SetFloat (Animator.StringToHash ("Speed"), vertical * speed);


		if (Input.GetButton ("Jump") && Time.time > nextJump) {
			rigidbody.AddForce(transform.up * jumpForce);
			nextJump = Time.time + jumpRate;
			audio.Play();
		}

	}
}
