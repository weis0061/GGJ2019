using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EndFirstPhase : MonoBehaviour {
    public GameObject[] disableOnPhaseExit;
    Collider collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BEe>() != null)
        {
            foreach(var obj in disableOnPhaseExit)
            {
                obj.SetActive(false);
            }

        }
    }
}
