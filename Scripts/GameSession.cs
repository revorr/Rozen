using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    //config parameters..
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
     public int pointsPerBlockDestroyed = 1;


    public int CurrentSceneIndex;

    [SerializeField] TextMeshProUGUI scoreText;
   // [SerializeField] TextMeshProUGUI lvlName;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] public GameObject  pauseButton,PausePannel;
   

    [SerializeField] public int lives;
    //[SerializeField] public int levels;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI ContinueText;
   

    public int points = 1;
    public GameObject gameOverPannel;
    public GameObject watchAdPannel;
    public GameObject lifeGainPannel;

    public bool gameOver;
    public bool lifeGain;
    public bool adWatch;
    public bool isContinued;
    public bool shouldDoubleScore;

    private AdTimer adtimer;


    public GameObject watchAdButton;
    //public AdManager adManager;


    //Vector2 paddleToBallDistance;





    //State Variables..
    public int currentScore = 0;
    public Paddle paddle;
    public Level level;
    Resume resume;
    BallScript ball;
  

   

    // it resets the game whenever the new game starts....
    private void Awake()   
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        
        if (gameStatusCount > 1 )
        {
            Destroy(gameObject);

            
        }
        else
        {
           DontDestroyOnLoad(gameObject);
            
        }
         
    }
    
   




    private void Start()
    {
        adtimer = FindObjectOfType<AdTimer>();
        //  isOptionPannelActive = GameObject.FindGameObjectWithTag("ContinuePannel").GetComponent<NonRewardAdScript>();

        // paddleToBallDistance = transform.position - paddle.transform.position;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + currentScore;
        highScoreText.text = "High Score: " + "/n" + PlayerPrefs.GetInt("HighScore", 0).ToString();


        if(Application.internetReachability != NetworkReachability.NotReachable)
        {
            Debug.Log("Network Cha");
           // WatchAd();
            Continue();

        }

        else
        {
            Debug.Log("Network Chaina");
           
            watchAdButton.GetComponent<Button>().enabled = false;
            watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adtimer.countdownText.gameObject.SetActive(false);
           ContinueText.gameObject.SetActive(false);
        }
    }



    // Update is called once per frame
    void Update () {
        
        Time.timeScale = gameSpeed; // sets the game speed....

    }


    

    


    // records the score per blocks destroyed....
    public void ScoreRecord()
    {     
        
       /* if(shouldDoubleScore)
        {
            currentScore = currentScore + pointsPerBlockDestroyed * 2;
        }
        */
        currentScore = currentScore + pointsPerBlockDestroyed * points;
        scoreText.text = "Score: " + currentScore.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScoreText.text = "New High Score:" + currentScore.ToString();
        }

        else
        {
            highScoreText.text = "High Score " + highScore ;  
                
                
        }
       
    }
  
    
  
    


    // resets the game....
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    
    


    


    // updates the level number......
 /*   public void UpdateLevels(int changeInLevels)
    {
        levels += changeInLevels;
        lvlName.text = "Level:" + levels.ToString();
       // lvlName.text = levels.ToString() ;
    }
    */
    



    // keeps the records of lives....
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        livesText.text = "Lives: " + lives;


        if (lives <= 0)
        {

            lives = 0;
            //GameOver();
            
            WatchAd();

        }

        

        livesText.text = "Lives: " + lives;
    }


    //code for gameover..
    public void GameOver()
    {
       // ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameOver = true;
        gameOverPannel.SetActive(true);   //it display the gameover pannel once all lives are finished..
    //  pauseButton.SetActive(true);
    //  watchAdPannel.SetActive(true);
    // PausePannel.SetActive(false);      

    }








    //play again..
    public void PlayAgain()
    { 
            SceneManager.LoadScene("Level1");
            Destroy(gameObject);
            gameOverPannel.SetActive(false);
           // level.levelCompletePannel.SetActive(false);         
    }

    public void Replay()
    {

        // SceneManager.LoadScene("StartScene");
        //  FindObjectOfType<GameSession>().ResetGame();


        // SceneManager.LoadScene("LevelMenu");
        // FindObjectOfType<GameSession>().ResetGame();




        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //  FindObjectOfType<GameSession>().ResetGame();

        ResetGame();
        SceneManager.LoadScene(CurrentSceneIndex);




        //Destroy(gameObject);


        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    public void Volume()
    {
        AudioListener.pause = !AudioListener.pause;
    }


    private void WatchAd()
    {
       // ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
       // paddle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        adWatch = true;
        Time.timeScale = 0f;
        watchAdPannel.SetActive(true);
        pauseButton.SetActive(false);
       
        //UpdateLives(1);
    }



    public void LifeGain()
    {

        lifeGain = true;
        lifeGainPannel.SetActive(true);
        // pauseButton.SetActive(false);
        // pausePannel.SetActive(false);

    }

    
    public void Continue()//it does not let to gain life more than once..
    {
        if (adWatch == true)
        {
            isContinued = true;
            UpdateLives(1);

            adtimer.TimerReset();

            watchAdButton.GetComponent<Button>().enabled = false;
            watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adtimer.countdownText.gameObject.SetActive(false);
            ContinueText.gameObject.SetActive(false);
            

        }
        

       /* else if (ball.hasStarted == true)
        {
            watchAdButton.GetComponent<Button>().enabled = true;
        }
        */
        
     //  watchAdButton.GetComponent<Button>().enabled = false;
     //  watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
       //DontDestroyOnLoad(watchAdButton);

    }

    public void Timer(){
            adtimer.countdownText.gameObject.SetActive(true);
        }

        public void TimerFalse()
   {
       adtimer.countdownText.gameObject.SetActive(false);

   }


  /*  public void StartGame()
    {
       // ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
       // paddle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        isContinued = true;
        UpdateLives(1);
        gameOverPannel.SetActive(false);
        watchAdPannel.SetActive(false);
        lifeGainPannel.SetActive(false);


    }
    */


    


}




