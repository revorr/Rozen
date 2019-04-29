using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    Button[] LevelButtons;
    public int ReachLevel;


    public void Awake()
    {
        ReachLevel = PlayerPrefs.GetInt("ReachLevel", 1);

        LevelButtons = new Button[transform.childCount];

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            LevelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            Debug.Log(ReachLevel);
            if (i + 1 > ReachLevel)
            {
                LevelButtons[i].interactable = false;
            }
        }

    }


}