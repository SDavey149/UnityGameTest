using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private ParticleSystem muzzleFlash;
	public int inflictedDamage;


	RaycastHit hit;
	public float range;
	Ray ray;

	private GameObject playerView;

	// Use this for initialization
	void Start () {
		playerView = GameObject.FindWithTag ("MainCamera");
		muzzleFlash = GameObject.Find ("ShotLocation").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		muzzleFlash.Stop();
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			ray.origin = playerView.transform.position;
			ray.direction = playerView.transform.forward;
			muzzleFlash.Play();
			audio.Play ();	
			if (Physics.Raycast (ray, out hit, range)) {
				nextFire = Time.time + fireRate;
				if (hit.collider.gameObject.tag == "Enemy") {
					HealthController health = hit.collider.gameObject.GetComponent<HealthController> ();
					if (health != null) {
						health.RemoveHealth(inflictedDamage);
					}
				}			
			}

		}
	}
	
}
