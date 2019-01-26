using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BEe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().velocity = new Vector3( Input.GetAxis("Horizontal") * Time.deltaTime*100,0,0);
        Debug.Log(Input.GetAxis("Horizontal"));
	}
}
