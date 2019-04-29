using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAd : MonoBehaviour
{
    static int loadCount = 0;
    // Start is called before the first frame update
    void Start()
    {
         if (loadCount % 3 == 0)  // only show ad every third time
        {
            ShowAdLevel();
        }
        loadCount++;
        
    }

   
    public void ShowAdLevel()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
