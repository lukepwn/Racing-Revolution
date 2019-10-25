using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapsText : MonoBehaviour
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
        laps.text = "Laps: "
            + CheckpointManager.instance.P1Laps.ToString()
            + "/2";

        if (CheckpointManager.instance.P1Laps == 3)
        {
            laps.text = "Complete";
        }
   
    }
}
