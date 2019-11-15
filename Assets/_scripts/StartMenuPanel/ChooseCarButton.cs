using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCarButton : MonoBehaviour
{
    // Instantiate and destroy the cars depending on which button has been pressed
    public GameObject Car1;
    public GameObject Car2;
    public GameObject P1Camera;
    public GameObject P2Camera;
    public GameObject Spawnpoint1;
    public GameObject Spawnpoint2;

   
    // enable start button
    public Button startButton;

    private string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        buttonName = this.gameObject.transform.name;
    }

    void TaskOnClick()
    {
        switch (buttonName)
        {
            case "P1Purple":
                Debug.Log("P1PURPLE");
                Destroy(GameObject.Find("P1PURPLE"));
                Destroy(GameObject.Find("P1GREEN"));;
                CreateCar(1, "PURPLE");
                break;
            case "P1Green":
                Debug.Log("P1GREEN");
                Destroy(GameObject.Find("P1PURPLE"));
                Destroy(GameObject.Find("P1GREEN")); ;
                CreateCar(1, "GREEN");
                break;
            case "P2Purple":
                Debug.Log("P2PURPLE");
                Destroy(GameObject.Find("P2PURPLE"));
                Destroy(GameObject.Find("P2GREEN")); ;
                CreateCar(2, "PURPLE");
                break;
            case "P2Green":
                Debug.Log("P2GREEN");
                Destroy(GameObject.Find("P2PURPLE"));
                Destroy(GameObject.Find("P2GREEN")); ;
                CreateCar(2, "GREEN");
                break;
            default:
                Debug.Log("Button not mapped");
                break;
        }


        startButton.interactable = true;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.buttonSound);
    }

    private void CreateCar(int player, string car)
    {
        switch (player)
        {
            // case player1 - 2 car options
            case 1:
                if (car == "PURPLE")
                {
                    GameObject carClone = Instantiate(Car1, Spawnpoint1.transform.position, Spawnpoint1.transform.rotation);
                    carClone.name = "P1PURPLE";
                    carClone.GetComponent<Player1Movement>().enabled = true;
                    GameObject cameraClone = Instantiate(P1Camera, carClone.transform.position + new Vector3(0, 3, 6), carClone.transform.rotation);
                    cameraClone.transform.SetParent(carClone.transform);
                    cameraClone.transform.rotation = Quaternion.Euler(13, 180, 0);
                    cameraClone.transform.SetParent(carClone.transform);
                }
                else if(car == "GREEN")
                {
                    GameObject carClone = Instantiate(Car2, Spawnpoint1.transform.position, Spawnpoint1.transform.rotation);
                    carClone.name = "P1GREEN";
                    carClone.GetComponent<Player1Movement>().enabled = true;
                    GameObject cameraClone = Instantiate(P1Camera, carClone.transform.position + new Vector3(0, 3, 6), carClone.transform.rotation);
                    cameraClone.transform.SetParent(carClone.transform);
                    cameraClone.transform.rotation = Quaternion.Euler(13, 180, 0);
                    cameraClone.transform.SetParent(carClone.transform);
                }
                break;
            // case player2 - 2 car options
            case 2:
                if (car == "PURPLE")
                {
                    GameObject carClone = Instantiate(Car1, Spawnpoint2.transform.position, Spawnpoint2.transform.rotation);
                    carClone.name = "P2PURPLE";
                    carClone.GetComponent<Player2Movement>().enabled = true;
                    GameObject cameraClone = Instantiate(P2Camera, carClone.transform.position + new Vector3(0, 3, 6), carClone.transform.rotation);
                    cameraClone.transform.SetParent(carClone.transform);
                    cameraClone.transform.rotation = Quaternion.Euler(13, 180, 0);
                    cameraClone.transform.SetParent(carClone.transform);
                }
                else if (car == "GREEN")
                {
                    GameObject carClone = Instantiate(Car2, Spawnpoint2.transform.position, Spawnpoint2.transform.rotation);
                    carClone.name = "P2GREEN";
                    carClone.GetComponent<Player2Movement>().enabled = true;
                    GameObject cameraClone = Instantiate(P2Camera, carClone.transform.position + new Vector3(0, 3, 6), carClone.transform.rotation);
                    cameraClone.transform.SetParent(carClone.transform);
                    cameraClone.transform.rotation = Quaternion.Euler(13, 180, 0);
                    cameraClone.transform.SetParent(carClone.transform);
                }
                break;
        } 
    }

}
