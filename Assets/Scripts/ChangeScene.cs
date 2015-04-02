using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
		
	public void SwitchScene(int level) {
		//IEnumerator
		
		//Fader fader = GameObject.Find("MainCamera").GetComponent<Fader>();
		//float fadeTime = fader.BeginFade(1);
		//yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (level);
	}

}
