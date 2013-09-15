using UnityEngine;
using System.Collections;

public class PortalEffect : MonoBehaviour {
	
	public GameObject destination;
	
	void OnTriggerStay(Collider other) {
		if( (other.transform.position - transform.position).magnitude < 0.1f ) {
			other.transform.position = destination.transform.position;	
		}
	}
	
}
