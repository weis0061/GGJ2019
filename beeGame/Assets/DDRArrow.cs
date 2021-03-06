﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(ParticleSystem))]
public class DDRArrow : MonoBehaviour {
    public Transform targettransform;
    bool gotIt = false;
    public float waitTime = 0.7F;
    public string inputBinding = "";
	
	// Update is called once per frame
	void Update () {
        if (!gotIt)
        {

            if (Input.GetButtonDown(inputBinding) || Input.GetAxis(inputBinding)>0.01F)
            {
                if (transform.position.y < targettransform.position.y + 1F)
                {
                    GetComponent<ParticleSystem>().Emit(3);
                    GetComponentInChildren<MeshRenderer>().enabled = false;
                    gotIt = true;
                }
            }
            if (transform.position.y < targettransform.position.y - 1F)
            {
                BeeHp.beeHp[0]--;
                if (BeeHp.beeHp[0] <= 0)
                {
                    BeeHp.beeHp[0] = 0;
                    Application.LoadLevel("SampleScene");
                }
                Destroy(gameObject);
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
