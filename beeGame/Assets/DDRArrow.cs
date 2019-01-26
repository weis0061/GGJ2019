using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(ParticleSystem))]
public class DDRArrow : MonoBehaviour {
    public Transform targettransform;
    bool gotIt = false;
    public float waitTimeMs = 300;
	
	// Update is called once per frame
	void Update () {
        if (!gotIt)
        {

            if (Input.GetButtonDown("Fire1"))
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
                Destroy(gameObject);
            }
        }
        else
        {
            waitTimeMs -= Time.deltaTime;
            if (waitTimeMs <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
