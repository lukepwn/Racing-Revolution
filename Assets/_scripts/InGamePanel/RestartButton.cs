using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour
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
        // Restart scene
        Debug.Log("restarting scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
