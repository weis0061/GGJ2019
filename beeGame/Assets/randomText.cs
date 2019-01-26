using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class randomText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var textlist = new string[]
        {
            "Convoluted",
            "They're",
            "Anthophila",
            "Dubious",
            "Yet",
            "Yeet",
            "Crawl",
            "Earth",
            "Fever",
            "Useful",
            "Zebra",
            "Cottage",
            "Evening",
            "Copying",
            "Usual",
            "Pioneer",
            "Noise",
            "Terrible",
            "Surprise",
            "Libraries",
            "Quarter",
            "Discover",
            "Wrecked"
        };
        GetComponent<TextMesh>().text = textlist[Random.Range(0, textlist.Length - 1)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
