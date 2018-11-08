using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour {
    public GameObject slingShot;
    public GameObject structure;

    // Use this for initialization
    void Start () {
        FocusSlingShot();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FocusSlingShot()
    {
        print("focusing on slingshot");
        gameObject.transform.DOMoveX(slingShot.transform.position.x, 1.5f);
    }

    public void FocusStructure()
    {
        print("focusing on structure");
        gameObject.transform.DOMoveX(structure.transform.position.x, 3);
    }
}
