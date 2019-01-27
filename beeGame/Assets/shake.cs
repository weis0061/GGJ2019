using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {
    static shake singleton;
    static float TimeLeft = 0;

    public static void shakeTheCamera(float duration=0.3f)
    {
        TimeLeft = duration;
        singleton.GetComponent<AudioSource>().Play();
    }

    Camera cam;
    float camFOV;

	// Use this for initialization
	void Start () {
        singleton = this;
        cam = GetComponent<Camera>();
        camFOV =cam.fieldOfView;
    }
	
	// Update is called once per frame
	void Update () {
        if (TimeLeft > 0)
        {
            cam.fieldOfView =camFOV- Mathf.Sin(Time.time * 60)*5;
            TimeLeft -= Time.deltaTime;
        }
        else
        {
            cam.fieldOfView = camFOV;
        }
	}
}
