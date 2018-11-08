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
    public Camera mainCam;

    private bool isWinState = false;
    private bool isLoseState = false;
    private Coroutine currentCoroutine = null;


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
        mainCam.GetComponent<CameraControl>().FocusStructure();
        if (ballCount <= 0)
        {
            //begin lose trigger routine
            StartCoroutine(DelayLose());
            ballCount = 0;
        } else
        {
            //focus on structure
            mainCam.GetComponent<CameraControl>().FocusStructure();
            //wait 3 seconds and relaunch ball
            currentCoroutine = StartCoroutine(SpawnNewBall());
        }
        //update ball counter
        uiBallCount.text = ballCount.ToString();
    }

    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(8);
        //focus on slingshot
        mainCam.GetComponent<CameraControl>().FocusSlingShot();

        slingShot.SendMessage("SpawnBall");
    }

    public void PrematureSpawnBall()
    {
        //halt the spawning coroutine
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        if (ballCount > 0)
        {
            print(ballCount);
            mainCam.GetComponent<CameraControl>().FocusSlingShot();
            slingShot.SendMessage("SpawnBall");
        } else
        {
            //instant fail
            LoseTrigger();
        }
    }

    IEnumerator DelayLose()
    {
        //all balls expended, wait till either loss or all enemies killed
        yield return new WaitForSeconds(8);
        LoseTrigger();
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
