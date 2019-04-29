using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour {

    public int CurrentSceneIndex;
    public bool haslevelChaged = false;

    BallScript ballscript;


    //cache references..
    public GameSession gSession;
    public Level level;
    Resume resume;
    //BallScript ballsacript;


    private Scene scene;


    public void Start()
    {
        // scene = SceneManager.GetActiveScene();

        gSession = FindObjectOfType<GameSession>();
    }


    //code to load next scene from built in index..
    public void LoadNextScene()
    {

        Time.timeScale = 1f;
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
        level.pauseButton.SetActive(true);
//gSession.watchAdButton.GetComponent<Button>().enabled = true;



        //level.pausePannel.SetActive(true);
        //resume.pauseButton.SetActive(false);        
        //level.levelCompletePannel.SetActive(false);



    }





    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");

    }


    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void LoadLevel9()
    {
        SceneManager.LoadScene("Level9");
    }
    public void LoadLevel10()
    {
        SceneManager.LoadScene("Level10");
        
    }
    public void LoadLevel11()
    {
        SceneManager.LoadScene("Level11");
    }
    public void LoadLevel12()
    {
        SceneManager.LoadScene("Level12");
    }

    public void LoadLevel13()
    {
        SceneManager.LoadScene("Level13");
    }
    public void LoadLevel14()
    {
        SceneManager.LoadScene("Level14");
    }
    public void LoadLevel15()
    {
        SceneManager.LoadScene("Level15");
    }
    public void LoadLevel16()
    {
        SceneManager.LoadScene("Level16");
    }
    public void LoadLevel17()
    {
        SceneManager.LoadScene("Level17");
    }
    public void LoadLevel18()
    {
        SceneManager.LoadScene("Level18");
    }
    public void LoadLevel19()
    {
        SceneManager.LoadScene("Level19");
    }
    public void LoadLevel20()
    {
        SceneManager.LoadScene("Level20");
    }
    public void LoadLevel21()
    {
        SceneManager.LoadScene("Level21");
    }
    public void LoadLevel22()
    {
        SceneManager.LoadScene("Level22");
    }
    public void LoadLevel23()
    {
        SceneManager.LoadScene("Level23");
    }
    public void LoadLevel24()
    {
        SceneManager.LoadScene("Level24");
    }
    public void LoadLevel25()
    {
        SceneManager.LoadScene("Level25");
    }
    public void LoadLevel26()
    {
        SceneManager.LoadScene("Level26");
    }
    public void LoadLevel27()
    {
        SceneManager.LoadScene("Level27");
    }
    public void LoadLevel28()
    {
        SceneManager.LoadScene("Level28");
    }
    public void LoadLevel29()
    {
        SceneManager.LoadScene("Level29");
    }
    public void LoadLevel30()
    {
        SceneManager.LoadScene("Level30");
    }
    public void LoadLevel31()
    {
        SceneManager.LoadScene("Level31");
    }
    public void LoadLevel32()
    {
        SceneManager.LoadScene("Level32");
    }
    public void LoadLevel33()
    {
        SceneManager.LoadScene("Level33");
    }
    public void LoadLevel34()
    {
        SceneManager.LoadScene("Level34");
    }
    public void LoadLevel35()
    {
        SceneManager.LoadScene("Level35");
    }
    public void LoadLevel36()
    {
        SceneManager.LoadScene("Level36");
    }
    public void LoadLevel37()
    {
        SceneManager.LoadScene("Level37");
    }
    public void LoadLevel38()
    {
        SceneManager.LoadScene("Level38");
    }
    public void LoadLevel39()
    {
        SceneManager.LoadScene("Level39");
    }
    public void LoadLevel40()
    {
        SceneManager.LoadScene("Level40");
    }
    public void LoadLevel41()
    {
        SceneManager.LoadScene("Level41");
    }
    public void LoadLevel42()
    {
        SceneManager.LoadScene("Level42");
    }
    public void LoadLevel43()
    {
        SceneManager.LoadScene("Level43");
    }
    public void LoadLevel44()
    {
        SceneManager.LoadScene("Level44");
    }
    public void LoadLevel45()
    {
        SceneManager.LoadScene("Level45");
    }
    public void LoadLevel46()
    {
        SceneManager.LoadScene("Level46");
    }
    public void LoadLevel47()
    {
        SceneManager.LoadScene("Level47");
    }
    public void LoadLevel48()
    {
        SceneManager.LoadScene("Level48");
    }
    public void LoadLevel49()
    {
        SceneManager.LoadScene("Level49");
    }
    public void LoadLevel50()
    {
        SceneManager.LoadScene("Level50");
    }



    public void ReplaySameLevel()
    {
      
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Destroy(gameObject);
        //  FindObjectOfType<GameSession>().ResetGame();

        gSession.ResetGame();


        SceneManager.LoadScene(CurrentSceneIndex);
        //gSession.watchAdButton.GetComponent<Button>().enabled = false;
       // gSession.watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);



    }


    /*  public void Replay()
      {

         // SceneManager.LoadScene("StartScene");
        //  FindObjectOfType<GameSession>().ResetGame();


          // SceneManager.LoadScene("LevelMenu");
          // FindObjectOfType<GameSession>().ResetGame();




          CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          FindObjectOfType<GameSession>().ResetGame();
          SceneManager.LoadScene(CurrentSceneIndex);




          //Destroy(gameObject);


          // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

      }
      */


    public void AboutUs()
    {
        SceneManager.LoadScene("About Us");
    }





    //loads the start scene..
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
        FindObjectOfType<GameSession>().ResetGame();
    }


    public void LoadMainScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadLevels()
    {
        SceneManager.LoadScene("LevelMenu");
        // FindObjectOfType<GameSession>().ResetGame();
    }

    //  public void replay(){}



    /*  public void SettingMenu()
      {
          SceneManager.LoadScene("SettingMenu");
      }
      */



    //it quits the game..
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }  
    

    
}
