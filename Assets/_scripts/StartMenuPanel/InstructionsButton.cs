using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsButton : MonoBehaviour
{

    public GameObject instructionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        instructionsPanel.SetActive(true);

        // highlight instructions back button
        instructionsPanel.transform.GetChild(4).GetComponent<Button>().Select();
        gameObject.transform.parent.gameObject.SetActive(false);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.buttonSound);
    }
}
