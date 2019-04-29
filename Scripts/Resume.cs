using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {


    [SerializeField] public GameObject pausePannel, pauseButton;
   

    public Paddle paddle;
    public Level level;
    public BallScript ballscript;
    GameSession gSession;

    public
 bool isPause;
    


    //it pauses game and pops up pause pannel..
    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pausePannel.SetActive(true);
        

       
    }

    //it resumes game..
    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pausePannel.SetActive(false);
       


    }




  




}
