using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutOfBounds : MonoBehaviour {
    public UnityEvent onEnter;
    //detect out of bounds
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            onEnter.Invoke();
        }
    }

}
