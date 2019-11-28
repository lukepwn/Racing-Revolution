/*
	AI Movement and calculations
	By: Luke Dam

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaypoints : MonoBehaviour
{
	public GameObject [] waypoints;
	public static float speed;
	
	private int current = 0;
	private float radius = 1;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
	
	private void Follow() 
	{
		//Debug.Log(Vector3.Distance(waypoints[current].transform.position, transform.position));
		
		if (Vector3.Distance(waypoints[current].transform.position, transform.position) < radius)
		{
			current ++;
			if (current >= waypoints.Length)
			{
				current = 0;
			}
		}
		
		transform.LookAt(waypoints[current].transform.position);
		transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
	}
}
