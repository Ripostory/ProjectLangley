using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour {
    //functionality to destroy object based on velocity and number of times hit
    public int hitPoints = 1;
    public float velocityThreshold = 1.0f;
    public UnityEvent onSlap;
    public UnityEvent onBreak;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if exceeds damage threshold
        string enemyTag = collision.gameObject.tag;
        string myTag = gameObject.tag;
        if (enemyTag == "Ball" || enemyTag == "Structure")
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                float impulse = collision.GetContact(i).normalImpulse;
                if (impulse > velocityThreshold)
                {
                    if (enemyTag == "Ball")
                    {
                        Slap(true);
                    } else
                    {
                        Slap(false);
                    }
                }
            }
        }
    }

    public void Slap(bool isBall)
    {
        //on significant damage
        hitPoints--;
        if (hitPoints <= 0)
        {
            //Alert listeners that object broke
            onBreak.Invoke();
            //object broke, destroy.
            Broken(isBall);
        } else
        {
            //alert listeners that object was hit
            onSlap.Invoke();
        }
    }

    public void Broken(bool isBall)
    {
        //call gibbing routine if available
        GibObject gibber = GetComponent<GibObject>();
        if (gibber != null)
        {
            if (isBall)
            {
                //assume hit with force
                gibber.isExplosion = true;
            } else
            {
                gibber.isExplosion = false;
            }
            gibber.SpawnGibs();
        } 

        Destroy(gameObject);
    }
}
