/*
	Victory screen name text logic 
	By: Kevin Kim
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPlayerNameText : MonoBehaviour
{
    Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        playerName = GetComponent<Text>();
        // if laps finished, turn on victory screen with P1
        if (CheckpointManager.instance.P1Laps == 1)
        {
            playerName.text = "Player 1 Wins";
        }

        if (CheckpointManager.instance.P2Laps == 1)
        {
            playerName.text = "Player 2 Wins";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
