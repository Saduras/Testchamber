using UnityEngine;
using System.Collections;

public class PortalCameraControl : MonoBehaviour {

	public Camera camera;
	public GameObject player;

	Vector3 viewDir = Vector3.forward;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateViewDir();
		camera.transform.LookAt( camera.transform.position - viewDir );
	}
	
	void UpdateViewDir() {
		viewDir =  transform.position - player.transform.position;	
		viewDir += transform.forward * viewDir.magnitude;
	}
}
