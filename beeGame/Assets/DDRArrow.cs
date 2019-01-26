using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(ParticleSystem))]
public class DDRArrow : MonoBehaviour {
    public Transform targettransform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<ParticleSystem>().Emit(3);
            Destroy(gameObject);
        }
        if (transform.position.y < targettransform.position.y-1F)
        {
            BeeHp.beeHp[0]--;
            Destroy(gameObject);
        }
	}
}
