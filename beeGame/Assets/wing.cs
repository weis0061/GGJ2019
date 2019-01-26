using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wing : MonoBehaviour {
    Vector3 initialRotation;
	// Use this for initialization
	void Start () {
        initialRotation = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        var newTransform = transform.localEulerAngles;
        newTransform.y= initialRotation.y + Mathf.Sin(Time.time*20)*45;
        transform.localEulerAngles = newTransform;
	}
}
