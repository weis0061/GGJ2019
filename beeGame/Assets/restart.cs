﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("SampleScene");
            BeeHp.beeHp[0] = 0;
        }
    }
}
