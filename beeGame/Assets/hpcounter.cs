using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpcounter : MonoBehaviour {
    public TextMesh txt;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = BeeHp.beeHp[0].ToString();
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0.1F, 0.9F, 0));
        pos.z = transform.position.z;
        transform.position = pos;
	}
}
