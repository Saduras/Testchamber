﻿using UnityEngine;
using System.Collections;

public class MainCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnPreRender() {
		GL.Clear(true, false, Color.red, 2f);	
	}
}
