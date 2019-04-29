using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


    [SerializeField] float ScreenWidthInUnit = 10f;
    //configurations parameters..

    

    [SerializeField] float minX = 1.8333f;
    [SerializeField] float maxX = 8.1666f;

    [SerializeField] float minScaleX = 1.7f, maxScaleX = 8.30f;
    [SerializeField] float minScaleNormalX = 1.13f, maxScaleNormalX = 8.69f;
  
    [SerializeField] bool isAutoPlayEnabled;
    public float speed = 200f;
  
    public bool hasPowerUp;
    public Vector2 temp;
    public float X = 1.3f;
    public float Y = 0.8f;

    public BlockScript blockScript;

    public float currentScale;
    public float paddleScale;


    //cached references..
    [SerializeField] GameSession gSession;
    [SerializeField] BallScript ball;
    [SerializeField] Resume resume;
    [SerializeField] Level level;
    private PowerUpsManager pManager;


    public bool doublepoints;
    //private bool safeMode;
    public float powerUpslength;  //time of power ups active..i.e duration..\


    // Rigidbody2D rb;  public float moveInput;



    // Use this for initialization
    void Start()
    {
       // currentScale = paddleScale;
        gSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<BallScript>();
        resume = FindObjectOfType<Resume>();
        //  adManager = GameObject.FindGameObjectWithTag("AdManager").GetComponent<AdManager>();

        pManager = FindObjectOfType<PowerUpsManager>();


    }

    // Update is called once per frame
    public void Update()
    {



        //locks the paddle if game is over...
        if (gSession.gameOver)
        {
            return;
        }
        


        //locks paddle if paused....
        if (resume.isPause)
        {
            return;
        }

        if (gSession.adWatch)
        {
            //TouchControll();
            MoveWithMouse();
        }

        if (level.isComplete)
        {
            
            return;


        }
        
        if(gSession.isContinued)
        {
            
           // MoveWithMouse();
           // TouchControll();
            MoveWithMouse();


        }
       


       
        

        if (!isAutoPlayEnabled)
        {
            MoveWithMouse();
            //MoveWithTouch();
          // TouchControll();
        }
        else
        {
            IsAutoPlayEnabled();
        }


        MoveWithMouse();


    }

    //moves paddle according to touch on screen.....
    private void MoveWithTouch()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
        {
            Debug.Log("U touched right side");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        else if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
        {
            Debug.Log("U touched left side");
            transform.position += Vector3.left * speed * Time.deltaTime;
        }


        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX);
        transform.position = PaddlePos;
    }

  

    public void TouchControll()
    {

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);

        if(Input.touchCount>0 && Input.GetTouch(0).phase ==TouchPhase.Moved)
        {
            Vector2 touchPosition = Input.GetTouch(0).deltaPosition;
            //   transform.Translate(touchPosition.x * speed * Time.deltaTime, 0, 0);
            transform.Translate(GetXpos() * speed * Time.deltaTime, 0, 0);
        }
     
    }


    public void MoveWithMouse()
    {
        float mousePos = (Input.mousePosition.x / Screen.width * ScreenWidthInUnit);
        Vector2 PaddlePos = new Vector2(mousePos, transform.position.y);
        PaddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX); //it defines min n max range where paddle can move..
        transform.position = PaddlePos;
    }

    
    
    // enables autoplay mode.....
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }


    public float GetXpos()    //Scripts for AutoPlay..
    {
        if (IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }

        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnit;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("ExtraLife")) //powerup for extra life...
        {
            gSession.UpdateLives(1);
            Destroy(other.gameObject);
        }


        if (other.CompareTag("PaddleScale")) //powerup for paddle scale up.....
        {
            PaddelNormal();
            StartCoroutine("PaddelNormal");
            AddTimeToScale(6f);
            Destroy(other.gameObject);

        }


        if (other.CompareTag("XpowerUps")) //power up for 2x score.....
        {
            // pManager.ActivatePowerups(doublepoints, powerUpslength);
             PowerUpScore(2);
             StartCoroutine(PowerUpScore(2));
          //  gSession.points *= 2;
            Destroy(other.gameObject);
        //    TwoXNormal();
         //   StartCoroutine("TwoXNormal");
         //   Destroy(other.gameObject);

        }    
        

    }

    public IEnumerator PowerUpScore(int time)
    {
        doublepoints = true;
        gSession.points *= 2;

        yield return new WaitForSeconds(time);

        doublepoints = false;
    }
    



    public void AddTimeToScale(float scaleTime  )
    {
        currentScale += scaleTime;

        if (currentScale > paddleScale)
        
            currentScale = paddleScale;
        
    }


    


    // brings the paddle to its original size....
    public IEnumerator PaddelNormal()
    {

        temp = transform.localScale;
        temp.x += Time.deltaTime;
        transform.localScale = new Vector2(X, Y);

        minX = minScaleX; //after power up is enabled it adjusts the screen position for paddle...
        maxX = maxScaleX;


        yield return new WaitForSeconds(6f);

        temp = transform.localScale;
        temp.x += Time.deltaTime;
        transform.localScale = new Vector2(1, Y);

        minX = minScaleNormalX; // when the power up ends it adjusts the screen posiotion for paddle...
        maxX = maxScaleNormalX;

    }


    public IEnumerator TwoXNormal()
    {
        gSession.currentScore += gSession.pointsPerBlockDestroyed * gSession.points;
       

        yield return new WaitForSeconds(5f);





        /* if (tag == "XPowerUps")
         {
             gSession.currentScore += gSession.pointsPerBlockDestroyed * gSession.points;
             gSession.points += 1;
         }

         yield return new WaitForSeconds(5f);

         if (tag == "XPowerUps")
         {
             gSession.currentScore += gSession.pointsPerBlockDestroyed * gSession.points;
            // gSession.points += 1;
             gSession.points -= 1;
         }

     */
    }
}


