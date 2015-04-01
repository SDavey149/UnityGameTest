using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour {

	public float speed;
	public float maxDistance;

	private float distanceMoved;
	private Vector3 dir;
	RobotShootBehaviour rsb;

	// Use this for initialization
	void Start () {
		distanceMoved = 0;
		dir = transform.forward;
		rsb = GetComponent<RobotShootBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!rsb.attack) { //if not attacking, move about
			if (distanceMoved >= maxDistance) {
				distanceMoved = 0;
				dir = -dir; 
			}
			transform.Translate (dir * speed * Time.deltaTime);
			distanceMoved += speed * Time.deltaTime;
		}


	}
}
