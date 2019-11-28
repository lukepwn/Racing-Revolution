/*
	Light switch calculation
	By: Luke Dam
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private GameObject[] car;
    public Light light;

    private float maxDist = 200f;

    void Start()
    {
        light = GetComponent<Light>();
        car = GameObject.FindGameObjectsWithTag("Player");
    }
    private void Update()
    {
        Distance();
    }

    private void Distance()
    {
		if (car.Length == 2) 
		{
			Transform car1 = car[0].transform;
			Transform car2 = car[1].transform;
			float dist1 = Vector3.Distance(car1.position, this.transform.position);
			float dist2 = Vector3.Distance(car2.position, this.transform.position);

			if (dist1 < maxDist || dist2 < maxDist)
			{
				light.enabled = true;
			}

			else
			{
				light.enabled = false;
			}
		}
		
		else
		{
			Transform car1 = car[0].transform;
			float dist1 = Vector3.Distance(car1.position, this.transform.position);
			
			if (dist1 < maxDist)
			{
				light.enabled = true;
			}

			else
			{
				light.enabled = false;
			}
		}

    }

}
