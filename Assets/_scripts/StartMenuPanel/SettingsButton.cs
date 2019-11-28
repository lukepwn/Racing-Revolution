/*
	Settings button logic for Start Menu
	By: Kevin Kim
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public GameObject settingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btn.Select();
    }

    void TaskOnClick()
    {
	    settingsPanel.SetActive(true);
	    settingsPanel.transform.Find("P1Purple").GetComponent<Button>().Select();

	    gameObject.transform.parent.gameObject.SetActive(false);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.buttonSound);
    }

}
