/*
	Choosing player 1 and player 2 car along with AI
	By: Kevin Kim, Luke Dam
*/

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
    public GameObject Heli;
	
	public Button p2purple;
	public Button p2green;
	public Button cpu;

    // enable start button
    public Button startButton;

    private string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        buttonName = this.gameObject.transform.name;
		togglebtn(false);
    }

	private void togglebtn(bool toggle)
	{
		p2green.enabled = toggle;
		p2purple.enabled = toggle;
		cpu.enabled = toggle;	
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
				togglebtn(true);
                // remove previously selected button color and set this button color
                selectedButton("P1Green", Color.gray);
                selectedButton("P1Purple", Color.magenta);
                break;
            case "P1Green":
                Debug.Log("P1GREEN");
                Destroy(GameObject.Find("P1PURPLE"));
                Destroy(GameObject.Find("P1GREEN"));
                CreateCar(1, "GREEN");
				togglebtn(true);
                selectedButton("P1Purple", Color.gray);
                selectedButton("P1Green", Color.green);
                break;
            case "P2Purple":
                Debug.Log("P2PURPLE");
                Destroy(GameObject.Find("P2PURPLE"));
                Destroy(GameObject.Find("P2GREEN"));
                CreateCar(2, "PURPLE");
				HeliOff();
                startButton.interactable = true;

                selectedButton("P2Purple", Color.magenta);
                selectedButton("P2Green", Color.gray);
                selectedButton("CPU", Color.gray);
                break;
				
            case "P2Green":
                Debug.Log("P2GREEN");
                Destroy(GameObject.Find("P2PURPLE"));
                Destroy(GameObject.Find("P2GREEN"));
                CreateCar(2, "GREEN");
				HeliOff();
                startButton.interactable = true;
                selectedButton("P2Purple", Color.gray);
                selectedButton("P2Green", Color.green);
                selectedButton("CPU", Color.gray);
                break;
				
			case "CPU":
				
				HeliOn();
                startButton.interactable = true;
                selectedButton("P2Purple", Color.gray);
                selectedButton("P2Green", Color.gray);
                selectedButton("CPU", Color.yellow);
                break;
				
            default:
                Debug.Log("Button not mapped");
                break;
        }


        SoundManager.Instance.PlayOneShot(SoundManager.Instance.buttonSound);
    }

    private void selectedButton(string buttonName, Color color)
    {
        GameObject.Find(buttonName).GetComponent<Button>().image.color = color;
    }

    // turn off the AI, enable the player2's UI and set camera to split screen
    private void HeliOff()
	{
		Heli.SetActive(false);
		GameObject.Find("P1Camera(Clone)").GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
	}

    // turn on the AI, disable the player2's UI and set camera to full screen
    private void HeliOn()
	{
		Destroy(GameObject.Find("P2PURPLE"));
        Destroy(GameObject.Find("P2GREEN"));
		Heli.SetActive(true);
		AIWaypoints.speed = 0;
		

		GameObject.Find("P1Camera(Clone)").GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
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
