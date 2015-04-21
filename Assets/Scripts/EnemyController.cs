using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	GameObject target;
	NavMeshAgent agent;
	Animator anim;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (target != null) {
			float distance = Vector3.Distance(transform.position, target.transform.position);
			if (distance > 6) {
				//move closer
				agent.enabled = true;
				anim.SetInteger("Speed", 1);
				agent.SetDestination(target.transform.position);

			}
			else if (agent.enabled) {
				anim.SetInteger("Speed", 0);
				agent.Stop ();
				agent.enabled = false;

			}

		}
		//agent.enabled = false;

	}
}
