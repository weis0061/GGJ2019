using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EndFirstPhase : MonoBehaviour {
    public GameObject[] disableOnPhaseExit;
    public GameObject[] enableOnPhaseExit;
    public Behaviour[] disableCompOnPhaseExit;
    Collider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		 if (Camera.main.transform.position.x > transform.position.x)
        {
            foreach(var obj in disableOnPhaseExit)
            {
                obj.SetActive(false);
            }
            foreach (var obj in disableCompOnPhaseExit)
            {
                obj.enabled = false;
            }
            foreach (var obj in enableOnPhaseExit)
            {
                obj.SetActive(true);
            }
        }
    }
	
  
    
       
}
