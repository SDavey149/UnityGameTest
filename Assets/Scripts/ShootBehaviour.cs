using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public ParticleSystem muzzleFlash;
	public int inflictedDamage;
	public Camera mainCamera;
	PlayerController player;


	RaycastHit hit;
	public float range;
	Ray ray;

	private GameObject playerView;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		muzzleFlash.Stop();
		if (player.ammo > 0 && Input.GetButton("Fire1") && Time.time > nextFire)
		{
			ray.origin = mainCamera.transform.position;
			ray.direction = mainCamera.transform.forward;
			muzzleFlash.Play();
			audio.Play ();	
			if (Physics.Raycast (ray, out hit, range)) {
				nextFire = Time.time + fireRate;
				if (hit.collider.gameObject.tag == "Enemy") {
					HealthController health = hit.collider.gameObject.GetComponent<HealthController> ();
					DisplaySparks sparks = hit.collider.gameObject.GetComponent<DisplaySparks>();
					if (health != null) {
						Debug.Log("Removed health");
						health.RemoveHealth(inflictedDamage);
						sparks.PlayDamageParticles();

					}
				}			
			}
			player.AddAmmo(-1);


		}
	}
	
}
