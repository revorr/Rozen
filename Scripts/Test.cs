using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public class Test : MonoBehaviour
{

    public Button level2Button, level3Button, level4Button, level5Button, level6Button, level7Button,
    level8Button, level9Button, level10Button, level11Button, level12Button, level13Button, level14Button,
    level15Button, level16Button, level17Button, level18Button, level19Button, level20Button, level21Button,
    level22Button, level23Button, level24Button, level25Button, level26Button,
    level27Button, level28Button,level29Button, level30Button, level31Button, level32Button, level33Button, level34Button, level35Button, 
    level36Button, level37Button, level38Button, level39Button, level40Button, level41Button, level42Button, 
    level43Button, level44Button, level45Button, level46Button, level47Button, level48Button, level49Button, 
    level50Button;
    

    public GameObject pannel1,pannel2;
    


    public LevelManager lm;
    public void GoNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int CurrentLevel = PlayerPrefs.GetInt("ReachLevel", 1);
        Debug.Log("CurrentLevel : " + CurrentLevel + "currentSceneIndex : " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex + 1);


        if (CurrentLevel == currentSceneIndex)
        {
            PlayerPrefs.SetInt("ReachLevel", CurrentLevel + 1);
            //Debug.Log(" if bata ayeko CurrentLevel : "+CurrentLevel+"currentSceneIndex : "+currentSceneIndex);
        }

        // }
    }
    public void resetPlayerPrefs()
    {
        level2Button.interactable = false;
        level3Button.interactable = false;
        level4Button.interactable = false;
        level5Button.interactable = false;
        level6Button.interactable = false;
        level7Button.interactable = false;
        level8Button.interactable = false;
        level9Button.interactable = false;
        level10Button.interactable = false;
        level11Button.interactable = false;
        level12Button.interactable = false;
        level13Button.interactable = false;
        level14Button.interactable = false;
        level15Button.interactable = false;
        level16Button.interactable = false;
        level17Button.interactable = false;
        level18Button.interactable = false;
        level19Button.interactable = false;
        level20Button.interactable = false;
        level21Button.interactable = false;
        level22Button.interactable = false;
        level23Button.interactable = false;
        level24Button.interactable = false;
        level25Button.interactable = false;
        level26Button.interactable = false;
        level27Button.interactable = false;
        level28Button.interactable = false;
        level29Button.interactable = false;
        level30Button.interactable = false;
        level31Button.interactable = false;
        level32Button.interactable = false;
        level33Button.interactable = false;
        level34Button.interactable = false;
        level35Button.interactable = false;
        level36Button.interactable = false;
        level37Button.interactable = false;
        level38Button.interactable = false;
        level39Button.interactable = false;
        level40Button.interactable = false;
        level41Button.interactable = false;
        level42Button.interactable = false;
        level43Button.interactable = false;
        level44Button.interactable = false;
        level45Button.interactable = false;
        level46Button.interactable = false;
        level47Button.interactable = false;
        level48Button.interactable = false;
        level49Button.interactable = false;
        level50Button.interactable = false; 

    

    
        
        PlayerPrefs.DeleteAll();
    }


    public void PannelSwitch1()
    {
        pannel2.SetActive(true);
        pannel1.SetActive(false);
    }


    public void PannelSwitch2()
    {

        pannel1.SetActive(true);
        pannel2.SetActive(false);

    }
}

