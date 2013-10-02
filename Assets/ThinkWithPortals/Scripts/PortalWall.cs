using UnityEngine;
using System.Collections;

public class PortalWall : MonoBehaviour {
	
	// the wall object this portal is attached to
	GameObject parentWall;
	
	/**
	 * Update parent wall after movement.
	 * Deactivate parent colldier to enable walking into the portal.
	 */ 
	public void SetParent(GameObject parent) {
		// reactivate collider of the old parent
		if( parentWall != null ) {
			parentWall.collider.enabled = true;
		}
		
		// set new parent and deactivate collider
		parentWall = parent;
		parentWall.collider.enabled = false;
	}
}
