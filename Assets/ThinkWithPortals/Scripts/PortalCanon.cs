using UnityEngine;
using System.Collections;

public class PortalCanon : MonoBehaviour {
	
	public GameObject bluePortalProjectil;
	public GameObject orangePortalProjectil;
	public float projectilImpuls;
	
	private GameObject barrel;
	
	// Use this for initialization
	void Start () {
		barrel = transform.Find("Main Camera/Barrel").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		// Shoot blue portal on left click
		if(Input.GetButtonDown("Fire1")) {
			GameObject handle = Instantiate(bluePortalProjectil, barrel.transform.position, transform.localRotation) as GameObject;
			handle.rigidbody.AddForce( barrel.transform.forward * projectilImpuls, ForceMode.Impulse);
		}
		
		// Shoot orange portal on right click
		if(Input.GetButtonDown("Fire2")) {
			GameObject handle = Instantiate(orangePortalProjectil, barrel.transform.position, transform.localRotation) as GameObject;
			handle.rigidbody.AddForce( barrel.transform.forward * projectilImpuls, ForceMode.Impulse);
		}
	}
}
