using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBackButton : MonoBehaviour
{
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        menuPanel.SetActive(true);
        // highlight start menu button
        menuPanel.transform.GetChild(0).GetComponent<Button>().Select();

        gameObject.transform.parent.gameObject.SetActive(false);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.buttonSound);
    }

}
