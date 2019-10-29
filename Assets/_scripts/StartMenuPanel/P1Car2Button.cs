using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Car2Button : MonoBehaviour
{
    //public GameObject Car1;
    public GameObject Car2;
    public GameObject P1Camera;

    public GameObject Spawnpoint;

    // to disable spawning of another car for player
    public Button P1ChooseOtherCar;
    // enable start button
    public Button startButton;


    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject carClone = Instantiate(Car2, Spawnpoint.transform.position, Spawnpoint.transform.rotation);
        carClone.name = "Player1Car";
        carClone.GetComponent<isCar1>().enabled = true;
        carClone.GetComponent<Player1Movement>().enabled = true;
        GameObject cameraClone = Instantiate(P1Camera, carClone.transform.position + new Vector3(0, 3, 6), carClone.transform.rotation);
        cameraClone.transform.SetParent(carClone.transform);
        cameraClone.transform.rotation = Quaternion.Euler(13, 180, 0);
        cameraClone.transform.SetParent(carClone.transform);



        this.GetComponent<Button>().interactable = false;
        P1ChooseOtherCar.interactable = false;
        startButton.interactable = true;
    }
}
