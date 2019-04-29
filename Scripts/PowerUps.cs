using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    [SerializeField] float speed;

    public GameSession gSession;

   // public bool doublepoints;
    //private bool safeMode;
   // public float powerUpslength;  //time of power ups active..i.e duration..\

 //   private PowerUpsManager pManager;



    // Update is called once per frame
    void Update () { //speed for powerups gravity..

        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);


        if(transform.position.y < -2f)
        {
            Destroy(gameObject);
        }


		
	}

  /*  public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.name == "paddle")
        {
            pManager.ActivatePowerups(doublepoints,powerUpslength);
        }
        Destroy(gameObject);
       // gameObject.SetActive(false);
        
    }
    */
}
