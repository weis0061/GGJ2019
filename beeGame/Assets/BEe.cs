﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BEe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().AddForce( new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime*200,
            Input.GetAxis("Vertical") * Time.deltaTime*800,0));
        Debug.Log(GetComponent<Rigidbody>().velocity);

	}
}
