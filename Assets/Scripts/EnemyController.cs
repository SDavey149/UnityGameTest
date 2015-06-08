using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	GameObject target;
	NavMeshAgent agent;
	Animator anim;
	public Transform shootOrigin;
	public float fireRate;
	float nextFire;
	bool attacking;

	Ray ray;
	RaycastHit hit;
	PlayerController player;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		attacking = false;
		nextFire = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (target != null) {
			float distance = Vector3.Distance(transform.position, target.transform.position);
			if (distance > 6) {
				attacking = false;
				//move closer
				agent.enabled = true;
				anim.SetFloat("Speed", 1);
				agent.SetDestination(target.transform.position);
				agent.velocity = new Vector3(0,0,0);

			}
			else if (agent.enabled) {
				attacking = true; //in range
				anim.SetFloat("Speed", 0);
				agent.Stop ();
				agent.enabled = false;

			}
			else if (distance < 6) {
				transform.LookAt(target.gameObject.transform.position);
			}

			if (attacking && Time.time > nextFire) {
				ray.origin = shootOrigin.position;
				ray.direction = shootOrigin.forward;
				audio.Play();
				if (Physics.Raycast (ray, out hit, 6f)) {
					if (hit.collider.gameObject.tag == "Player") {
						target.GetComponent<PlayerController>().AddHealth(-20);
					}
				}
				nextFire = Time.time + fireRate;
			}

		}
		//agent.enabled = false;

	}
}
