/*
	Exit button logic for the victory screen
	By: Kevin Kim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        // Exit scene (only works in compiled .exe 
        Application.Quit();
    }
}
