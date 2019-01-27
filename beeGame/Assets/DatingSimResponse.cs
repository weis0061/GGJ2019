using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DatingSimResponse : MonoBehaviour {
    public DatingSim datingSimManager;
    public bool correctAnswer;

    void OnMouseUpAsButton()
    {
        if(correctAnswer)
        datingSimManager.selectOption(this);
        else
        datingSimManager.mistake();
    }
}
