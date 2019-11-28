/*
	UI: Text for P1 checkpoints count
	By: Kevin Kim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1CheckpointsText : MonoBehaviour
{
    Text Checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        Checkpoints = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Checkpoints.text = "Checkpoints: " 
            + CheckpointManager.instance.cleared1num.ToString()
            + "/4";
    }
}
