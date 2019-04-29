using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;


public class AdController : MonoBehaviour {

    public static AdController instance;
    // static int loadCount = 0;
    public static int loadCount = 1;

    private string store_id = "3121845";
    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "bannerAd";

 GameSession gSession;

   // public bool getLife = false;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        Monetization.Initialize(store_id, false);

        // if (loadCount % 3 == 0)  // only show ad every third time
        // {
        //     ShowVideoOrInterstitialAd();
        // }
        // loadCount++;
        AdsGenerate();

    }

    // Update is called once per frame
    void Update()
    {

        // if(level.isComplete)
        // {

        // //is the video ad ready to be played
        // 	if(Monetization.IsReady(video_ad))
        // {
        // 	ShowAdPlacementContent ad = null;
        // 	ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

        // 	if(ad != null)
        // 	{
        // 		ad.Show();
        // 	}
        // }

        // }

    }

    public void AdsGenerate()
   {
       if (loadCount % 3 == 0)  // only show ad every third time
       {
           ShowVideoOrInterstitialAd();
       }
       loadCount++;

   }

    public void ShowVideoOrInterstitialAd()
    {

        if (Monetization.IsReady(video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }


    }

    public void RewardVideo()
    {
        if (Monetization.IsReady(rewarded_video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
               // gSession.UpdateLives(1);

            }
        }
    }


    public void PlayBanner()
    {

        // if(ball.hasStarted == true){
        // 	ball.LockBallToPaddle();
        // }

        if (Monetization.IsReady(banner_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
                

            }
        }


    }

   /* private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player gained life");
                // gSession.StartGame();
                // gSession.Continue();
                getLife = true;

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

    */


}

