using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    //Static instance of CheckpointManager which allows it to be accessed by any other script.
    public static CheckpointManager instance = null;

    // checkpoint cleared counts for each player
    private bool P1Cleared;
    private bool P2Cleared;

    // number for checking consecutive checkpoints clearing
    public int cleared1num = 0;
    public int cleared2num = 0;

    // laps count for each player
    public int P1Laps = 0;
    public int P2Laps = 0;

    public GameObject CheckpointWall1;
    public GameObject CheckpointWall2;
    public GameObject CheckpointWall3;
    public GameObject CheckpointWall4;

    // victory screen & music
    public GameObject EndGamePanel;
    public AudioClip victoryMusic;
    private int gameEnded;

    // disable minimap
    public GameObject minimap;


    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkPointTrack();
        LapCleared();
        if (gameEnded == 1)
        {
            VictoryMusic();
            gameEnded++;
        }
    }

    void checkPointTrack()
    {
        // tracking first car
        if (CheckPointWall1.instance.P1Clear)
        {
            cleared1num = 1;

            if (CheckPointWall2.instance.P1Clear)
            {
                cleared1num = 2;

                if (CheckPointWall3.instance.P1Clear)
                {
                    cleared1num = 3;

                    if (CheckPointWall4.instance.P1Clear && cleared1num == 3)
                    {
                        cleared1num = 0;
                        P1Laps++;
                        CheckPointWall1.instance.P1Clear = false;
                        CheckPointWall2.instance.P1Clear = false;
                        CheckPointWall3.instance.P1Clear = false;
                        CheckPointWall4.instance.P1Clear = false;
                    }
                }
            }
        }
        // tracking second car
        if (CheckPointWall1.instance.P2Clear)
        {
            cleared2num = 1;

            if (CheckPointWall2.instance.P2Clear)
            {
                cleared2num = 2;

                if (CheckPointWall3.instance.P2Clear)
                {
                    cleared2num = 3;

                    if (CheckPointWall4.instance.P2Clear && cleared2num == 3)
                    {
                        cleared2num = 0;
                        P2Laps ++;
                        CheckPointWall1.instance.P2Clear = false;
                        CheckPointWall2.instance.P2Clear = false;
                        CheckPointWall3.instance.P2Clear = false;
                        CheckPointWall4.instance.P2Clear = false;
                    }
                }
            }
        }
    } 

    // method for showing the victory screen upon completing a lap
    void LapCleared()
    {
        if (P1Laps == 1 || P2Laps == 1)
        {
            // disable minimap & enable victory screen
            minimap.SetActive(false);
            EndGamePanel.SetActive(true);
            // freezes the game
            Time.timeScale = 0.0f;
            gameEnded++;
        }
    }

    // play victory music once upon game finish
    void VictoryMusic()
    {
        SoundManager.Instance.PauseMusic();
        SoundManager.Instance.PlayOneShot(victoryMusic);
        SoundManager.Instance.setEffectVolume(0.1f);
    }
}
