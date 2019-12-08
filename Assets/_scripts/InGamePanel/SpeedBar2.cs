/*
	UI: Text for P2 Speed count
	By: Luke Dam
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar2 : MonoBehaviour
{
    public Image bar;
    public Text speed;
	public Text warning;
    //public GameObject gobar1;
    //public GameObject gobar2;
    // Start is called before the first frame update
    //void Awake()
    //{
    //    //Fill(.1f);
    //}

    //public void Fill(float speed)
    //{
    //    bar.fillAmount = speed;
    //}

    private void Fill()
    {

        bar.fillAmount = Player2Movement.speedText / 200;
        speed.text = Player2Movement.speedText + " KM/H";


    }
	
	private void WarningText() 
	{
		if (Player2Movement.speedText > 150 && Player2Movement.slipText != "Drifting!!!") 
		{
			warning.text = "Slow down!!!";
		}
		
		else if (Player2Movement.slipText != null)
			warning.text = Player2Movement.slipText;
		else 
		{
			warning.text = "";
		}
		
	}

    void Update()
    {
        Fill();
		WarningText();

    }
}
