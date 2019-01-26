using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(spin))]
[RequireComponent(typeof(AudioSource))]
public class BEe : MonoBehaviour {
    public bool CanControl=true;
    public int BeeNum = 1;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (CanControl)
        {
            GetComponent<Rigidbody>().AddForce( 
            new Vector3(Input.GetAxis("Horizontal"+BeeNum) * Time.deltaTime*300,
                        Mathf.Max(Input.GetAxis("Vertical"+BeeNum) * Time.deltaTime*1000,
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
            GetComponent<spin>().enabled = true;
            var sound = GetComponent<AudioSource>();
            sound.Play();
        }
    }
}
