using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    public int enemyCount = 2;
    public int ballCount = 3;

    //references to UI
    public Text uiEnemyCount;
    public Text uiBallCount;
    public Image winPanel;
    public Image losePanel;

    private bool isWinState = false;
    private bool isLoseState = false;


    //references for active slingshot
    public GameObject slingShot;

	// Use this for initialization
	void Start () {
        //spawn ball
        slingShot.SendMessage("SpawnBall");
        //set starting values
        uiEnemyCount.text = enemyCount.ToString();
        uiBallCount.text = ballCount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyKilled()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            //all enemies killed
            WinTrigger();
        }

        //update enemy counter
        uiEnemyCount.text = enemyCount.ToString();
    }

    public void BallUsed()
    {
        ballCount--;
        
        if (ballCount <= 0)
        {
            //all balls expended, wait till either loss or all enemies killed
            LoseTrigger();
            ballCount = 0;
        } else
        {
            //wait 3 seconds and relaunch ball
            StartCoroutine(SpawnNewBall());
        }
        //update ball counter
        uiBallCount.text = ballCount.ToString();
    }

    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(3);
        slingShot.SendMessage("SpawnBall");
    }

    void WinTrigger()
    {
        if (!isLoseState)
        {
            isWinState = true;
            winPanel.GetComponent<DisplayWin>().Display();
            print("WIN TRIGGER FIRED");
        } else
        {
            print("Scene is already in a lose state!");
        }
    }

    void LoseTrigger()
    {
        if (!isWinState)
        {
            isLoseState = true;
            losePanel.GetComponent<DisplayWin>().Display();
            print("LOSE TRIGGER FIRED");
        }
        else
        {
            print("Scene is already in a win state!");
        }
    }
}
