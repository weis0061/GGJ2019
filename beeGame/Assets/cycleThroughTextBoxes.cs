﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleThroughTextBoxes : MonoBehaviour {
    float timeTillNextBox = 1f;
    public GameObject[] boxes;
    int boxIndex = 0;
    public GameObject[] activateAfterDDRComplete;
    public GameObject[] deactivateAfterDDRComplete;
    public Behaviour[] activateAfterDDRCompleteComp;
    public Behaviour[] deactivateAfterDDRCompleteComp;
    public Transform boxTopLeft;
    public Transform boxTopRight;
    GameObject lastCreatedbox;

    // Update is called once per frame
    void Update () {
        timeTillNextBox -= Time.deltaTime;
        if (timeTillNextBox <= 0)
        {
            if (boxIndex < boxes.Length)
            {
                timeTillNextBox = 3f + Random.value;
                var pos = new Vector3(
                    Random.Range(boxTopLeft.position.x, boxTopRight.position.x),
                    Random.Range(boxTopLeft.position.y, boxTopRight.position.y),
                    Random.Range(boxTopLeft.position.z, boxTopRight.position.z)
                    );
                if (lastCreatedbox != null)
                    Destroy(lastCreatedbox);
                lastCreatedbox = Instantiate(boxes[boxIndex], pos, Quaternion.identity);

                boxIndex++;
            }
            else
            {
                Destroy(lastCreatedbox);
                foreach (var obj in activateAfterDDRComplete)
                {
                    obj.SetActive(true);
                }
                foreach (var obj in activateAfterDDRCompleteComp)
                {
                    obj.enabled=(true);
                }
                foreach (var obj in deactivateAfterDDRComplete)
                {
                    obj.SetActive(false);
                }
                foreach (var obj in deactivateAfterDDRCompleteComp)
                {
                    obj.enabled = (false);
                }
                Destroy(gameObject);
            }
        }
	}
}
