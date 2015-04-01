using UnityEngine;
using System.Collections;

public class RobotShootBehaviour : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public bool attack;
	private float nextFire;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		attack = false;
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Player" && Time.time > nextFire)
				attack = true;
	}

	void OnTriggerStay(Collider c) {

		if (c.gameObject.tag == "Player" && Time.time > nextFire) {
			transform.LookAt (player.transform);
			nextFire = Time.time + fireRate;
			GameObject bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			BulletBehaviour bb = bullet.GetComponent<BulletBehaviour>();
			bb.target = player.transform.position;
			audio.Play ();
		}
			
	}

	void OnTriggerExit(Collider c) {
		attack = false;
	}


}
