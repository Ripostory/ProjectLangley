using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibObject : MonoBehaviour {
    public GameObject gibGroup;
    public Material gibMaterial;
    public bool isExplosion = false;
    public float explosionForce = 800.0f;

    //used for gibbing the selected object
	public void SpawnGibs()
    {
        GameObject gibs = Instantiate(gibGroup, gameObject.transform.position, gameObject.transform.rotation);

        //set material for gibs
        Renderer[] renderers = gibs.GetComponentsInChildren<Renderer>();
        foreach (Renderer gibRender in renderers)
        {
            gibRender.material = gibMaterial;
        }
        

        //apply explosive force if explosion is enabled
        if (isExplosion)
        {
            Explode();
        }
    }

    void Explode()
    {
        Vector3 explodePos = gibGroup.transform.position;
        explodePos.z += 5.0f;
        float radius = 15.0f;
        Collider[] colliders = Physics.OverlapSphere(explodePos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody body = hit.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.AddExplosionForce(explosionForce, explodePos, radius);
            }
        }
    }
}
