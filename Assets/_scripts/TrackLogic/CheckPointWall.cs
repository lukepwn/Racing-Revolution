using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointWall : MonoBehaviour
{
    public bool P1Clear;
    public bool P2Clear;
    public static CheckPointWall instance = null;

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
        if (other.gameObject.GetComponent<isCar1>())
        {
            P1Clear = true;
            Debug.Log("P1Checkpoint trigger");
        }

        if (other.gameObject.GetComponent<isCar2>())
        {
            P2Clear = true;
            Debug.Log("P2Checkpoint trigger");
        }
    }

}
