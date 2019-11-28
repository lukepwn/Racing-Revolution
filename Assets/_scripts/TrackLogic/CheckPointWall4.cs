/*
	Checkpoint Wall 4's script for checking a player's passed status
	By: Kevin Kim
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointWall4 : MonoBehaviour
{
    public bool P1Clear;
    public bool P2Clear;
    public bool AIClear;

    public static CheckPointWall4 instance = null;

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

    // turn on trigger on unity editor on the collider component
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player1Movement>().enabled == true)
        {
            P1Clear = true;
            Debug.Log("P1Checkpoint4 trigger");
        }

        if (other.gameObject.GetComponent<Player2Movement>().enabled == true)
        {
            P2Clear = true;
            Debug.Log("P2Checkpoint4 trigger");
        }

        if (other.gameObject.tag == "AI")
        {
            AIClear = true;
            Debug.Log("AI Checkpoint4 trigger");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
