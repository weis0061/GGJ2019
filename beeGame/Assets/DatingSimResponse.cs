using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DatingSimResponse : MonoBehaviour {
    public DatingSim datingSimManager;

    void OnMouseDownAsButton()
    {
        datingSimManager.selectOption(this);
    }
}
