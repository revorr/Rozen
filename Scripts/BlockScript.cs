using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] GameObject extraBalls;
    [SerializeField] int timesHit;
    [SerializeField] bool isSpecial;

    GameSession gSession;
    Level level;
   


    public void Start()
    {
        isSpecial = (this.tag == "SpecialBlock");
        CountBreakableBlocks();
    }



    public void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if(tag == "Breakable" || tag =="SpecialBlock")
        {
            level.CountBlocks();


        }

        
    }




    public void OnCollisionEnter2D(Collision2D other)
    {

        if (tag == "Breakable" || tag =="SpecialBlock" )
        {
            HandleHits();
        }


        if (isSpecial)
        {
            HandleSpecial();
        }
      
    }

    

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if(timesHit >= maxHits)
        {
            BlockDestroy();
        }

        else
        {
            ShowNextHitSprites();
        }
    }


    public void HandleSpecial()
    {
        PlaySoundOnDestroy();
        TriggerSparklesVFX();
        Destroy(gameObject);

        int numNewBalls = Random.Range(2, 3);
        for(int i= 0; i < numNewBalls; i++)
        {
            GameObject newBall = Instantiate(extraBalls, transform.position, Quaternion.identity) as GameObject;
            Destroy(newBall, 4f);
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(3f, 12f));
        }
    }

    

    public void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;

        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

        else
        {
            Debug.LogError("Block Sprite is missing from array" + gameObject.name);
        }
    }



    public void BlockDestroy()
    {
       // FindObjectOfType<GameSession>().ScoreRecord();
        PlaySoundOnDestroy();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
       
    }



    public void PlaySoundOnDestroy()
    {
        FindObjectOfType<GameSession>().ScoreRecord();

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }



    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }



}
