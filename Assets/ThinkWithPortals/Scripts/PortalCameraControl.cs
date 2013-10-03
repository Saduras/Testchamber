using UnityEngine;
using System.Collections;

public class PortalCameraControl : MonoBehaviour {
	
	public GameObject otherPortal;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// use offset of main camera to other portal to place this portal view camera
		Vector3 posOffset = otherPortal.transform.InverseTransformPoint( Camera.main.transform.position );
		Vector3 localPos = new Vector3( - posOffset.x, posOffset.y, - posOffset.z);
		//transform.localPosition =  - posOffset;
		Debug.DrawLine( transform.parent.position, transform.position );
		Debug.DrawLine( otherPortal.transform.position, otherPortal.transform.TransformPoint( posOffset )  );
		
		//camera.nearClipPlane = posOffset.magnitude;
		
		Quaternion rotOffset = otherPortal.transform.rotation;
		Quaternion rotCorrection = Quaternion.AngleAxis(180f, new Vector3(0,1,0));
		transform.localRotation = rotCorrection * Quaternion.Inverse( rotOffset ) * Camera.main.transform.rotation;
	}
}
