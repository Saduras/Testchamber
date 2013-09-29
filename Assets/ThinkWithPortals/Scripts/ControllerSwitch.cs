using UnityEngine;
using System.Collections;

public class ControllerSwitch : MonoBehaviour {

	// store the character controller and it's double
	public CloneControl[] playerController;
	// distance we start activating the double
	public float doubleAcitvationDist;
	
	// references to both portals
	GameObject[] portals;
	// current distance between active player controller and portals
	float[] portalDist;
	// index of the nearest portal
	int near;
	int far;
	
	// tell us which controller is currently active
	int active = 0;

	// Use this for initialization
	void Start () {
		// initialize controller activation
		for(int i=0; i<playerController.Length; i++) {
			if(i == active) {
				// activate the default controller
				playerController[i].Show(true);
				playerController[i].Change(true);
			} else {
				// deactivate other controller
				playerController[i].Show(false);
				playerController[i].Change(false);
			}
		}
		// init portal references and distances
		portals = new GameObject[2];
		portals[0] = GameObject.Find("PortalBlue");
		portals[1] = GameObject.Find("PortalOrange");
		portalDist = new float[portals.Length];
	}
	
	// Update is called once per frame
	void Update () {
		// calculate distance between portals and active player controller
		portalDist[0] = (portals[0].transform.position - playerController[active].transform.position).magnitude;
		portalDist[1] = (portals[1].transform.position - playerController[active].transform.position).magnitude;
		
		// find nearest portal
		if( portalDist[0] <= portalDist[1] ) {
			near = 0;
			far = 1;
		} else {
			near = 1;
			far = 0;
		}
		
		int clone = active == 0 ? 1 : 0;
		
		// check this distance
		if( portalDist[near] <= doubleAcitvationDist ) {
			// show clone
			if( !playerController[clone].IsVisible ) {
				playerController[clone].Show( true );
			}
			
			// use offset of active player controller to the nearest portal to place the clone
			Vector3 posOffset = portals[near].transform.InverseTransformPoint( playerController[active].transform.position );
			playerController[clone].transform.position = portals[far].transform.TransformPoint( - posOffset );
			
			Quaternion rotOffset = portals[far].transform.rotation;
			Quaternion rotCorrection = Quaternion.AngleAxis(180f, new Vector3(0,1,0));
			playerController[clone].transform.rotation = rotCorrection * rotOffset * Quaternion.Inverse( portals[near].transform.rotation ) * playerController[active].transform.rotation;
			
		} else {
			// hide clone
			if( playerController[clone].IsVisible ) {
				playerController[clone].Show( false );
			}
		}
	}
}
