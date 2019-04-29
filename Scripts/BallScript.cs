using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallScript : MonoBehaviour
{


    //config parameters..

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFact = 0.4f;
    [SerializeField] GameSession gSession;

    [SerializeField] public Transform lifePowerUps;
    [SerializeField] public Transform scalePowerups;
    [SerializeField] public Transform xPowerUps;

    



    //States
    Vector2 paddleToBallDistance;
    public bool hasStarted = false;
    public bool watchAd;
    public int whichPowerUps;


    //cached Component reference..
    AudioSource myAudio;
    Rigidbody2D myRigidbody2D;
    Transform ballScale;


    BlockScript blockScripts;
    [SerializeField] Level level;
    [SerializeField] Resume resume;
    AdManager adManager;






    // Use this for initialization
    void Start()
    {


        paddleToBallDistance = transform.position - paddle1.transform.position;
        myAudio = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
       // myRigidbody2D.AddForce(Vector2.up * 500);
        resume = FindObjectOfType<Resume>();
        gSession = GameObject.FindGameObjectWithTag("GameSession").GetComponent<GameSession>();
       // adManager = GameObject.FindGameObjectWithTag("AdManager").GetComponent<AdManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (gSession.gameOver)  //freezes ball movements..
        {
            LockBallToPaddle();
            return;
        }
        

        if(gSession.lifeGain)
        {
            return;
        }


        if (resume.isPause)  //It freezes the game when pause button is pressed..
        {

            Time.timeScale = 0;
            return;

        }

        if (level.isComplete)  //It freezes the game when level is completed..
        {
            Time.timeScale = 0f;
            gSession.isContinued = true;
            return;
        }



        if (gSession.isContinued)
        {



            // Debug.Log("game is continued");
            // LaunchOnMouseClicked();
            LaunchOnMouseClicked();
            LockBallToPaddle();
            
        }
        

        


        if (gSession.adWatch)
        {
            //LockBallToPaddle();
            //LaunchOnMouseClicked();
            return;
        }
        

        

        if (gameObject.tag != "ExtraBall")  //it checks the tag extraball..
        {
            if (!hasStarted)
            {

                LockBallToPaddle();
                LaunchOnMouseClicked();
               
            }

        }

       
    }


    public void LaunchOnMouseClicked() //ball launch with mouse click..
    {
        if (Input.GetMouseButtonUp(0))
        {
           gSession.isContinued = false;
            gSession.adWatch = false;
          //  gSession.lifeGain = false;
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
           // Debug.Log("U hav clicked");
         
        }
    }





    public void LockBallToPaddle()  //ball is lock in the paddle..
    {
        
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;

    }

    // when the ball hits the buttom collider and checks the tag then it looses life..  
    private void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.CompareTag("LooseLives") && tag != "ExtraBall")
        if (other.CompareTag("LooseLives") && tag != "ExtraBall")
        {
           
            myRigidbody2D.velocity = Vector2.zero;
            hasStarted = false;
            gSession.UpdateLives(-1);
        }
    }
        

    // when the ball collides with the blocks then powerups falls randomly..
    public void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweek = new Vector2
            (Random.Range(0f, randomFact), Random.Range(0f, randomFact));


        if (other.transform.CompareTag("Breakable"))
        {
            whichPowerUps = Random.Range(1, 7);
            int randomChance = Random.Range(0, 101);

            if (whichPowerUps == 1 && randomChance < 30)
            {
                Instantiate(lifePowerUps, other.transform.position, transform.rotation);
                
            }


            if (whichPowerUps == 2 && randomChance < 30)
            {
                Instantiate(scalePowerups, other.transform.position, transform.rotation);
            }

            if (whichPowerUps == 3 && randomChance < 15)
            {
                Instantiate(xPowerUps, other.transform.position, transform.rotation);
            }




        }

        if (hasStarted == true) //here game audio is checked..
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];  //here we select multiple sounds from array                                                                               
            myAudio.PlayOneShot(clip);   //plays one sound clip..
            myRigidbody2D.velocity += velocityTweek;

        }





    }

    
}
