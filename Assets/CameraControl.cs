using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour {
    public GameObject slingShot;
    public GameObject structure;

    // Use this for initialization
    void Start () {
        StartAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FocusSlingShot()
    {
        print("focusing on slingshot");
        Vector3 position = slingShot.transform.position;
        position.y = slingShot.transform.position.y + 5.0f;
        position.z = gameObject.transform.position.z;
        gameObject.transform.DOMove(position, 1.5f);
    }

    public void FocusStructure()
    {
        print("focusing on structure");
        Vector3 position = structure.transform.position;
        position.y = structure.transform.position.y + 15.0f;
        position.z = gameObject.transform.position.z;
        gameObject.transform.DOMove(position, 3);
    }

    public void StartAnimation()
    {
        Sequence seq = DOTween.Sequence();
        Vector3 position = structure.transform.position;
        position.y = structure.transform.position.y + 15.0f;
        position.z = gameObject.transform.position.z;
        seq.Append(transform.DOMove(position, 3));
        seq.Append(transform.DOMove(position, 3));
        Vector3 positionSling = slingShot.transform.position;
        positionSling.y = slingShot.transform.position.y + 5.0f;
        positionSling.z = gameObject.transform.position.z;
        seq.Append(transform.DOMove(positionSling, 1.5f));
    }
}
