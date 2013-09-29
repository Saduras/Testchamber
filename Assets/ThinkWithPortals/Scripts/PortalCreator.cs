using UnityEngine;
using System.Collections;

public class PortalCreator : MonoBehaviour {
	
	public GameObject portalPrefab;
	
	void OnCollisionEnter(Collision collision) {
		// Check if we hit a valid ground for an portal
		// We tagged all valid areas with "PortalGround"
		if( collision.gameObject.CompareTag("PortalGround") ) {
			// search for an existing portal
			GameObject portal = GameObject.Find(portalPrefab.name);
			
			if( portal == null ) {
				// create new portal if we didn't find one
				GameObject handle = Instantiate(portalPrefab, collision.transform.position - collision.transform.forward * 0.01f, collision.transform.rotation * Quaternion.AngleAxis(90f, new Vector3(1,0,0)) ) as GameObject;
				// get rid of the "(clone)" name extension
				handle.name = portalPrefab.name;
			} else {
				// move exiting portal to new position
				portal.transform.position = collision.transform.position - collision.transform.forward * 0.01f;
				portal.transform.rotation = collision.transform.rotation;// * Quaternion.AngleAxis(90f, new Vector3(1,0,0));
			}
		}
		
		// Destroy this projectil
		Destroy( gameObject );
	}
}
