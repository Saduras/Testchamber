using UnityEngine;
using System.Collections;

public class PortalCameraControl : MonoBehaviour {
	
	public GameObject otherPortal;
	

	// Use this for initialization
	void Start () {
		
		Matrix4x4 m = new Matrix4x4();
		Matrix4x4 m_sym = new Matrix4x4();
		
		
		// http://www.songho.ca/opengl/gl_projectionmatrix.html
		float l = -0.0002886836f * 20;
		float r = 0.0002886836f * 20;
		float b = -0.0000057735f * 20;
		float t = 0.0000057735f * 20;
		float n = 0.03f;
		float f = 20f;
		
		m[0,0] = 2*n/(r-l); m[0,1] = 0; m[0,2] = r+l/(r-l); m[0,3] = 0;
		m[1,0] = 0; m[1,1] = 2*n/(t-b); m[1,2] = t+b/(t-b); m[1,3] = 0;
		m[2,0] = 0; m[2,1] = 0; m[2,2] = -(f+n)/(f-n); m[2,3] = -2*f*n/(f-n);
		m[3,0] = 0; m[3,1] = 0; m[3,2] = -1; m[3,3] = 0;
		
		//camera.projectionMatrix = m;
		Debug.Log( camera.projectionMatrix );
	}
	
	// Update is called once per frame
	void Update () {
		// use offset of main camera to other portal to place this portal view camera
		Vector3 posOffset = otherPortal.transform.InverseTransformPoint( Camera.main.transform.position );
		Vector3 localPos = new Vector3( - posOffset.x, posOffset.y, - posOffset.z);
		transform.localPosition =  localPos;
		Debug.DrawLine( transform.parent.position, transform.position );
		Debug.DrawLine( otherPortal.transform.position, otherPortal.transform.TransformPoint( posOffset )  );
		
		//camera.nearClipPlane = posOffset.magnitude;
		
		Quaternion rotOffset = otherPortal.transform.rotation;
		Quaternion rotCorrection = Quaternion.AngleAxis(180f, new Vector3(0,1,0));
		transform.localRotation = rotCorrection * Quaternion.Inverse( rotOffset ) * Camera.main.transform.rotation;
	}
}
