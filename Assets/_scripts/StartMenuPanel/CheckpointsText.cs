using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointsText : MonoBehaviour
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
