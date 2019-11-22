using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
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
        
        bar.fillAmount = Player1Movement.speedText / 170;
        speed.text = Player1Movement.speedText + " KM/H";
    }
	
	private void WarningText() 
	{
		//Debug.Log(Player1Movement.slipText);
		if (Player1Movement.speedText > 250 && Player1Movement.slipText != "Drifting!!!") 
		{
			warning.text = "Slow down!!!";
		}
		
		else if (Player1Movement.slipText != null)
			warning.text = Player1Movement.slipText;
		
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
