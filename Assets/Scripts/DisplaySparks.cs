using UnityEngine;
using System.Collections;

public class DisplaySparks : MonoBehaviour {
	public ParticleSystem sparks;
	

	public void PlayDamageParticles() {
		sparks.Play ();
	}
	
}
