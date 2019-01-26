using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class honeycomb : MonoBehaviour {
    bool gotem = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gotem)
        {
            var target = Camera.main.ViewportToWorldPoint(new Vector3(0.1F, 0.9F, transform.position.z));
            target.z = transform.position.z;
            var vec = (transform.position - target);
            vec.z = 0;
            vec = vec * Time.deltaTime * 2;
            transform.position = transform.position - vec;
            if (Vector3.Distance(transform.position, target) < 1F)
            {
                Destroy(gameObject);
            }
        }
	}
    void OnTriggerEnter(Collider c)
    {
        var bee = c.gameObject.GetComponent<BEe>();
        if (bee!=null)
        {
            GetComponent<wavyMove>().enabled = false;
            GetComponent<Move>().enabled = false;
            gotem = true;
            BeeHp.beeHp[0]++;
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<TextMesh>().text = "";
            var sound = GetComponent<AudioSource>();
            sound.Play(); 
        }
    }
}
