﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playbutton : MonoBehaviour {

       

        void OnMouseUpAsButton ()
        {
           
            Application.LoadLevel("SampleScene");
        }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
