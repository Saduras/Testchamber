using UnityEngine;
using System.Collections;

public class TeleportTrigger : MonoBehaviour {
	
	ControllerSwitch cSwitch;
	
	// Use this for initialization
	void Start () {
		cSwitch = GameObject.Find("Player").GetComponent<ControllerSwitch>();
	}
	
	public void OnTriggerEnter(Collider other) {
		if( other.gameObject.CompareTag("Player") ) {
			cSwitch.Switch();
		}
	}
}
