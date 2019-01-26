using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BEe : MonoBehaviour {
    public bool CanControl=true;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (CanControl)
        {
            GetComponent<Rigidbody>().AddForce( 
            new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime*200,
                        Mathf.Max(Input.GetAxis("Vertical") * Time.deltaTime*800,
                        0),0));
        }
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<Outofbounds>() != null)
        {
            //we've hit OOB
            CanControl = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
