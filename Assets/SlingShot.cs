using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour {
    public GameObject ball;
    public GameObject logicController;

    private bool isLoaded = false;


    public void SpawnBall()
    {
        if (!isLoaded)
        {
            //spawn in a new ball for the slingshot
            GameObject currentBall = Instantiate(ball, transform.position, transform.rotation);
            currentBall.GetComponent<PullAndRelease>().sling = this;
            isLoaded = true;

        } else
        {
            print("Slingshot is already loaded!");
        }

    }

    public void BallLaunched()
    {
        //called by the instantiated ball
        isLoaded = false;

        //send message to logic controller of usage
        logicController.GetComponent<GameLogic>().SendMessage("BallUsed");

        print("ball launched");
    }
}
