using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;
    public TextMeshProUGUI countdownText;
    public GameObject gameOverPanel;
    public GameObject WatchAdPanel;

    private GameSession gSession;
    public TextMeshProUGUI ContinueText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        gSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {

        TimeCountDown();

    /*    if (gSession.gameOver == true)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {

                gameOverPanel.SetActive(true);
                WatchAdPanel.SetActive(false);
            }
        }
        */

    }

    

    public void TimeCountDown()
    {
        if (gSession.lives <= 0)
        {
            
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {

            gSession.watchAdButton.GetComponent<Button>().enabled = false;
            gSession.watchAdButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            currentTime = 0;
            ContinueText.gameObject.SetActive(false);

            }
            
        }
    }
    public void TimerReset()
        {
            currentTime = startingTime;
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }

}
