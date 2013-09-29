using UnityEngine;
using System.Collections;

public class CloneControl : MonoBehaviour {
	
	public Camera cam;
	public AudioListener audioListener;
	public MouseLook mouse;
	public FPSInputController keyboard;
	public PortalCanon canon;
	
	bool isClone;
	bool isVisible;
	
	public void Change(bool status) {
		if( status == true ) {
			isClone = false;
			cam.enabled = true;
			audioListener.enabled = true;
			mouse.enabled = true;
			keyboard.enabled = true;
			canon.enabled = true;
		} else {
			isClone = true;
			cam.enabled = false;
			audioListener.enabled = false;
			mouse.enabled = false;
			keyboard.enabled = false;
			canon.enabled = false;
		}
	}
	
	public void Show( bool status ) {
		isVisible = status;
		gameObject.SetActive( status );
	}
	
	// getter
	public bool IsClone {
		get {
			return this.isClone;
		}
	}

	public bool IsVisible {
		get {
			return this.isVisible;
		}
	}
}
