using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndRelease : MonoBehaviour {
    private Vector3 startPos;
    public float force = 1000f;

    //set when instantiated
    public SlingShot sling;

	// Use this for initialization
	void Start () {
        startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDrag()
    {
        // Convert mouse position to world position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane hPlane = new Plane(Vector3.forward, Vector3.zero);
        float distance = 50f;
        Vector3 p = Vector3.zero;
        if (hPlane.Raycast(ray, out distance))
        {
            // get the hit point:
            p = ray.GetPoint(distance);
        }
        

        // Keep it in a certain radius
        float radius = 1.8f;
        Vector3 dir = p - startPos;
        dir.z = startPos.z;
        if (dir.magnitude > radius)
            dir = dir.normalized * radius;
        if (dir.x > 0.0f)
            dir.x = 0.0f;

        // Set the Position
        transform.position = startPos + dir;
    }

    private void OnMouseUp()
    {
        // Disable isKinematic
        GetComponent<Rigidbody2D>().isKinematic = false;

        //yeet
        Vector3 dir = startPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);

        //notify parent of launching
        sling.SendMessage("BallLaunched");

        // Remove the Script (not the gameObject)
        Destroy(this);
    }

}
