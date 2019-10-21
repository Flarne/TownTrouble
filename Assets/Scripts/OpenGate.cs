using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	public bool enter = true;
	public bool exit = true;
	float smooth = 5.0f;

	private void Awake()
	{
		//Quaternion gateTarget = Quaternion.Euler(0.0f, 90.0f, 0.0f);
		//transform.rotation = Quaternion.Slerp(transform.rotation, gateTarget, Time.deltaTime * smooth);
	}

	//private void Update()
	//{
	//	OpeningGate();
	//}

	//private void OpeningGate()
	//{
		
	//}

	private void OnTriggerEnter(Collider other)
	{
		if (enter)
		{
			Debug.Log("entered");
			GetComponent<Animator>().SetBool("Opening", true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (exit)
		{
			Debug.Log("Exited");
		}
	}
}
