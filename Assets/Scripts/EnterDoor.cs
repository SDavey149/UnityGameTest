using UnityEngine;
using System.Collections;

public class EnterDoor : MonoBehaviour {
	
	void OnTriggerEnter() {
		GetComponent<ChangeScene>().SwitchScene(2);
	}
}
