﻿/*
	Sign rotation
	By: Luke Dam
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
	
	private void Movement() 
	{
		transform.Rotate(new Vector3 (100f, 0f, 0f) * Time.deltaTime);
	}
	
}
