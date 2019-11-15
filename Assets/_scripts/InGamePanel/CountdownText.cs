using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    private float count;
    Text countdown;
    public GameObject player1Car;
    public GameObject player2Car;

    private int p1;
    private int p2;

    // Start is called before the first frame update
    void Start()
    {
        countdown = GetComponent<Text>();
        count = 3;

        if (GameObject.Find("P1PURPLE") != null)
        {
            p1 = 1;
        }
        if (GameObject.Find("P1GREEN") != null)
        {
            p1 = 2;
        }

        if (GameObject.Find("P2PURPLE") != null)
        {
            p2 = 1;
        }
        if (GameObject.Find("P2GREEN") != null)
        {
            p2 = 2;
        }

        if (p1 == 1)
        {
            player1Car = GameObject.Find("P1PURPLE");
        }
        else
        {
            player1Car = GameObject.Find("P1GREEN");
        }

        if (p2 == 1)
        {
            player2Car = GameObject.Find("P2PURPLE");
        }
        else
        {
            player2Car = GameObject.Find("P2GREEN");
        }

        player1Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        player2Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        count = count - Time.deltaTime;
        //Debug.Log(count);
        countdown.text = count.ToString("F0");

        if (count <= 0)
        {
            player1Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            player2Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
