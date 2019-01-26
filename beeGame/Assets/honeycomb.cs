using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeycomb : MonoBehaviour {
    bool gotem = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gotem)
        {
            var target = Camera.main.ViewportToWorldPoint(new Vector3(0.1F, 0.1F, 0));
            target.z = transform.position.z;
            transform.Translate((transform.position - target) * Time.deltaTime * 10);
            if (Vector3.Distance(transform.position, target) < 1F)
            {
                Debug.Log(Vector3.Distance(transform.position, target));
                Destroy(gameObject);
            }
        }
	}
    void OnTriggerEnter(Collider c)
    {
        var bee = c.gameObject.GetComponent<Bee>();
        if (bee!=null)
        {
            gotem = true;
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<TextMesh>().text = "";
        }
    }
}
