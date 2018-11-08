using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour {
    public void TakeDamage()
    {
        //make object redder as more damage is taken
        Material mat = GetComponent<Renderer>().material;
        Color color = mat.color;
        color.g -= 0.3f;
        color.b -= 0.3f;
        mat.color = color;
    }
}
