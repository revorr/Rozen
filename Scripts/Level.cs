using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class Level : MonoBehaviour {


    //parameters..
    [SerializeField] int breakableBlocks;
    [SerializeField] public GameSession gSession;
    public GameObject levelCompletePannel;

    //[SerializeField] TextMeshProUGUI highScoreTextt;
   // public TextMeshProUGUI urScoreIs;
    public bool isComplete = false;


    //cache references..
    public LoadScene loadScene;
    BallScript ballscript;
    Resume resume;
    //private AdTimer adtimer;
    AdController adcontroller;
    AdManager admanager;
    
  
    [SerializeField] public GameObject pausePannel, pauseButton;

    //public TextMeshProUGUI ContinueText;



    private void Start()
    {
        gSession = FindObjectOfType<GameSession>();
        loadScene = FindObjectOfType<LoadScene>();
    
    }


    //counts and add the numbers of blocks..
    public void CountBlocks()
    { 
        breakableBlocks++; //blocks add..
    }


    public void BlockDestroyed()
    {
        breakableBlocks--; //decreases the blocks number after it is being destroyed..

        if (breakableBlocks <= 0 )
        {

           
            isComplete = true;
            // RewardAdScript.Instance.ShowAdNormal();
            //RewardAdvertisement.adReward.ShowNormalAd();

           // AdController.instance.ShowVideoOrInterstitialAd();
           AdController.instance.AdsGenerate();
            
            // gSession.watchAdButton.GetComponent<Button>().enabled = true;
            // gSession.watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            // gSession.ContinueText.gameObject.SetActive(true);
            //gSession.Timer();
            

            levelCompletePannel.SetActive(true);
            
            pauseButton.SetActive(false);

            if (Application.internetReachability != NetworkReachability.NotReachable)
           {
               Debug.Log("Network Cha");
               gSession.watchAdButton.GetComponent<Button>().enabled = true;
               gSession.watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
               gSession.Timer();
               gSession.ContinueText.gameObject.SetActive(true);

           }

           else
           {
               Debug.Log("Network Chaina");

               gSession.watchAdButton.GetComponent<Button>().enabled = false;
               gSession.watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
               gSession.TimerFalse();
               gSession.ContinueText.gameObject.SetActive(false);

           }

           
        }

        else if (gSession.lifeGain == true)
       {
           gSession.GameOver();
       }

       
    }
}
