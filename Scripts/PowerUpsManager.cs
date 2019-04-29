using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{

    private bool doublepoints;
    //private bool safeMode;
    private bool powerUpsActive;  //time of power ups active..i.e duration..\

    private float powerupLengthCounter;
    private GameSession gSession;

    private int normalPointsPerBlocks;





    // Start is called before the first frame update
    void Start()
    {
        gSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {

        if(powerUpsActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if(doublepoints)
            {
                gSession.pointsPerBlockDestroyed = normalPointsPerBlocks * 2;
                gSession.shouldDoubleScore = true;
            }

            if(powerupLengthCounter <= 0)
            {
                gSession.pointsPerBlockDestroyed = normalPointsPerBlocks;
                gSession.shouldDoubleScore = false;
                powerUpsActive = false;

            }
        } 
        
    }

    public void ActivatePowerups(bool points, float time)
    {
        doublepoints = points;
        powerupLengthCounter = time;

        normalPointsPerBlocks = gSession.pointsPerBlockDestroyed;

        powerUpsActive = true;
         
    }
}
