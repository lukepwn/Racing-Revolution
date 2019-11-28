﻿/*
	UI: Text for P1 laps count
	By: Kevin Kim
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1LapsText : MonoBehaviour
{
    Text laps;

    // Start is called before the first frame update
    void Start()
    {
        laps = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        laps.text = "Lap "
            + CheckpointManager.instance.P1Laps.ToString()
            + "/1";   
    }
}
