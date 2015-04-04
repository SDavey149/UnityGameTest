using UnityEngine;
using System.Collections;



public class CameraLook : MonoBehaviour {
	
	public float lookSpeed;
	float pitch;
	private float pitchVelocity = 0f;

	void Start() {
		Screen.lockCursor = true;
	}	

	void FixedUpdate() {


	}

	void LateUpdate() {
		float mouseY = Input.GetAxis ("Mouse Y") * lookSpeed;
		float newPitch = Mathf.Clamp (pitch + mouseY, -80, 70);
		//make it smooth
		pitch = Mathf.SmoothDamp (pitch, newPitch, ref pitchVelocity, 0.1f);
		transform.rotation = Quaternion.Euler (pitch, 0, 0);
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, 0, 0);
	}

}
