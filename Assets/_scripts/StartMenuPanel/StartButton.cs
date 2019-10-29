using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public AudioClip gameSoundTrack;

    public GameObject GameLevel;
    public GameObject MenuPanel;
    public GameObject IngamePanel1;
    public GameObject IngamePanel2;
    public GameObject CheckpointManager;
    public GameObject CountdownPanel;

    public GameObject SpeedometerPanel1;
    public GameObject SpeedometerPanel2;

    private GameObject [] lightArray;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btn.onClick.AddListener(LightOn);
        btn.interactable = false;
    }

    void TaskOnClick()
    {
        Debug.Log("Turning on GameLevel");
        GameLevel.SetActive(true);
        Debug.Log("Turning off Menu");
        MenuPanel.SetActive(false);
        Debug.Log("Turning on IngamePanel");
        IngamePanel1.SetActive(true);
        Debug.Log("Turning on IngamePanel2");
        IngamePanel2.SetActive(true);
        Debug.Log("Turning on CheckpointManager");
        CheckpointManager.SetActive(true);
        Debug.Log("Turning on CountdownPanel");
        CountdownPanel.SetActive(true);

        Debug.Log("Turning on Speedometer1");
        SpeedometerPanel1.SetActive(true);
        Debug.Log("Turning on Speedometer2");
        SpeedometerPanel2.SetActive(true);



        // turn off menu music & play gameplay music
        SoundManager.Instance.PauseMusic();
        SoundManager.Instance.PlayMusic(gameSoundTrack);
        SoundManager.Instance.setMusicVolume(0.2f);
    }

    void LightOn()
    {
        lightArray = GameObject.FindGameObjectsWithTag("Light");

        foreach (GameObject i in lightArray)
        {
            i.GetComponent<LightSwitch>().enabled = true;
        }
    }
}
