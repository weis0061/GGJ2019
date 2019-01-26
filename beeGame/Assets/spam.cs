using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class spam : MonoBehaviour {
    public GameObject[] SpamThese;
    public Transform FromArea;
    public Transform ToArea;
    public float spamDelayMilliseconds;
    bool spamSomething = false;

    Thread t;
	void Start () {
	// Use this for initialization
        t = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep((int)spamDelayMilliseconds);
                spamSomething = true;
            }
        });
        t.Start();
	}

    // Update is called once per frame
    void Update()
    {
        if (spamSomething)
        {
            spamSomething = false;
            var go = SpamThese[Mathf.RoundToInt(Random.Range(0, SpamThese.Length-1))];
            var position = (FromArea.position - ToArea.position) * Random.value + ToArea.position;
            Instantiate(go, position, Quaternion.identity);
        }
    }

    void OnDestroy()
    {
        t.Abort();
    }
}
