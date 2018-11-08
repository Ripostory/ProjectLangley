using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DisplayWin : MonoBehaviour {

	public void Display()
    {
        //show win screen with animation
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        transform.DOAnchorPosY(0, 1);
    }
}
