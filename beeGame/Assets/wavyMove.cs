using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class wavyMove : MonoBehaviour {
    Move m;
    Vector3 initialMove;
    public float intensity = 5f;
    public float frequency = 5f;
    // Use this for initialization
    void Start () {
        m = GetComponent<Move>();
        initialMove = m.move;
	}
	
	// Update is called once per frame
	void Update () {
        m.move.y = initialMove.y + Mathf.Sin(Time.time*frequency)*intensity;
	}
}
