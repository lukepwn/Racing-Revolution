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
    }

    void TaskOnClick()
    {
        settingsPanel.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
        Debug.Log("turning off:" + gameObject.transform.parent.gameObject);
    }

}
