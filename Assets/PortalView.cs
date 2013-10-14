using UnityEngine;
using System.Collections;

public class PortalView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(renderer.material.renderQueue);
		renderer.material.renderQueue = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
