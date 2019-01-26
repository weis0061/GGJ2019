using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDR : MonoBehaviour {
    public float delay = 0.3F;
    public Transform[] arrowSpawnPoints;
    public GameObject[] Arrows;
    float delayLeft = 0f;
	// Use this for initialization
	void Start () {
        delayLeft = delay;
	}
	
	// Update is called once per frame
	void Update () {
        delayLeft -= Time.deltaTime;
        if (delayLeft <= 0)
        {
            delayLeft = delay;
            for(int i = 0; i < arrowSpawnPoints.Length; i++)
            {
                if (Random.value > 0.7f)
                {

                    var pos = arrowSpawnPoints[i].position;
                    pos.y = transform.position.y;
                    var arrow = Instantiate(Arrows[i], pos, Quaternion.identity);
                    arrow.transform.parent = transform;
                    arrow.GetComponent<DDRArrow>().targettransform = arrowSpawnPoints[i];
                }
            }
        }
	}
}
