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

    // Start is called before the first frame update
    void Start()
    {
        countdown = GetComponent<Text>();
        count = 3;
        player1Car = GameObject.Find("Player1Car");
        player2Car = GameObject.Find("Player2Car");
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
