using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PortalCameraControl : MonoBehaviour {
	
	public GameObject otherPortal;
	public float horizObl;
	public float vertObl;

	// Use this for initialization
	void Start () {
	}
	
	
	void OnPreRender() {
		// get main camera relative position to otherPortal
		Vector3 pos = otherPortal.transform.InverseTransformPoint( Camera.main.transform.position );
		// invert x and z value
		// otherwise you get a mirrored movement
		pos.x = - pos.x;
		pos.z = - pos.z;
		
		// apply position relativ to parent portal
		transform.localPosition = pos;
		
		// get relativ rotation
		Quaternion rot = Quaternion.Inverse( otherPortal.transform.rotation ) * Camera.main.transform.rotation;
		rot = Quaternion.AngleAxis(180.0f, new Vector3(0,1,0)) * rot;
		
		// apply rotation relative to parent portal
		transform.localRotation = rot;
		
		// change near clip plane to parent portal 
		// get clip plane pos & normal
		/*Vector3 cpos = transform.parent.position;
		Vector3 cnormal = transform.parent.forward;
		
		
		float right = camera.nearClipPlane * Mathf.Tan( camera.fieldOfView * Mathf.Rad2Deg );
		camera.projectionMatrix = ObliqueFrustum( camera.nearClipPlane, camera.farClipPlane, right, right / camera.aspect, cnormal);
		Debug.Log( camera.projectionMatrix );*/
	}
	
	Matrix4x4 ObliqueFrustum( float near, float far, float right, float top, Vector3 clipNormal ) {
		//clipNormal = camera.transform.TransformDirection( clipNormal );
		Debug.Log( near );
		Matrix4x4 m = StandardSymmetricFrustum( near, far, right, top );
		m = camera.projectionMatrix;
		// horizontal oblique
		m[0,2] = horizObl;
		// vertical oblique
		m[1,2] = vertObl;
		
		return m;
	}
	
	Matrix4x4 StandardSymmetricFrustum( float near, float far, float right, float top ) {
		Matrix4x4 m = new Matrix4x4();
		
		// row 0 -> x projection
		m[0,0] = near / right;
		m[0,1] = 0;
		m[0,2] = 0;
		m[0,3] = 0;
		// row 1 -> y projection
		m[1,0] = 0;
		m[1,1] = near / top;
		m[1,2] = 0;
		m[1,3] = 0;
		// row 2 -> z projection
		m[2,0] = 0;
		m[2,1] = 0;
		m[2,2] = -(far + near)/(far - near);
		m[2,3] = - 2 * far * near /(far - near);
		// row 3 -> w projection
		m[3,0] = 0;
		m[3,1] = 0;
		m[3,2] = -1;
		m[3,3] = 0;
			
		return m;
	}
	
	/*void OnDrawGizmos() {
		// draw correct frustum depending on projection matrix
		Matrix4x4 m = camera.projectionMatrix;
		m.SetRow(3, new Vector4(0,0,0,1) );
		m.SetColumn(3, new Vector4(0,0,0,1) );
		Matrix4x4 inverse = m.inverse;
		//Debug.Log( inverse );
		
		Vector3[] vecs = {
			new Vector3(-1,1,0),
			new Vector3(1,1,0),
			new Vector3(1,-1,0),
			new Vector3(-1,-1,0),
			new Vector3(-1,1,1),
			new Vector3(1,1,1),
			new Vector3(1,-1,1),
			new Vector3(-1,-1,1),
		};
		
		for(int i=0; i<vecs.Length; i++) {
			vecs[i] = transform.TransformPoint( inverse.MultiplyPoint3x4( vecs[i] ) );
		}
		
		for( int i=1; i < 4; i++ ) {
			Gizmos.DrawLine( vecs[i-1], vecs[i] );
			Gizmos.DrawLine( vecs[i+3], vecs[i+4] );
			Gizmos.DrawLine( vecs[i], vecs[i+4] );
		}
		Gizmos.DrawLine( vecs[0], vecs[4] );
		Gizmos.DrawLine( vecs[3], vecs[0] );
		Gizmos.DrawLine( vecs[7], vecs[4] );
	}*/
}
