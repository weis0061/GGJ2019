using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wing : MonoBehaviour {
    static bool whichWing=false;
    Vector3 initialRotation;
    public bool rightWing = false;
	// Use this for initialization
	void Start () {
        initialRotation = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        var newTransform = transform.localEulerAngles;
        newTransform.y= initialRotation.y + Mathf.Sin(Time.time*20)*45 * (rightWing ? 1 : -1);
        transform.localEulerAngles = newTransform;
	}
}
