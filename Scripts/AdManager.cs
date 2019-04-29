using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    [SerializeField] GameSession Gm;
 
    // public bool isResume = false;
    // public GameObject LifeGainPanel;	
        private string store_id = "3014909";
    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "bannerAd";

    Resume resume;
    GameSession gSession;

    Vector2 paddleToBallVector;
    static int loadCount = 0;

    //public GameObject WatchAdPanel;


    public bool getLife = false;


    // Use this for initialization
    void Start()
    {
        //Gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameStatus>();
        //paddleToBallVector = transform.position - paddle1.transform.position;

        if (loadCount % 3 == 0)  // only show ad every third time
        {
            ShowAdLevel();
        }
        loadCount++;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
           
        }
    }
     public void ShowAdLevel()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player gained life");
                // gSession.StartGame();
               // gSession.Continue();
                getLife = true;
               // gSession.UpdateLives(1);

                break;

            case ShowResult.Skipped:
                Debug.Log("Player did not watch the full ad");
                break;

            case ShowResult.Failed:
                Debug.Log("Internet Connection Lost");
                break;
        }
        if (result == ShowResult.Finished)
        {
            Debug.Log("Finsihed watching ad");
            //  ball.LaunchOnMouseClick();
            //  ball.LockBallToPaddle();
            // Time.timeScale = 1f;
            // Gm.UpdateLives(1);
        }
    }

    //   public void ResumeForLife()
    //     {       
    //         isResume = true;
    //         LifeGainPanel.SetActive(false);
    //         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    // 		SceneManager.LoadScene(currentSceneIndex);
    //         ball.LockBallToPaddle();
    //         ball.LaunchOnMouseClick();
    //         Gm.UpdateLives(1);
    //     }



}


