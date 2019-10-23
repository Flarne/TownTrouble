using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	[SerializeField] Animator openGate;

	public bool enter = true;
	public bool exit = true;
	float smooth = 5.0f;

	private void Start()
	{
		openGate.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (enter)
		{
			openGate.enabled = true;
			Debug.Log("entered");
			GetComponent<Animator>().SetTrigger("opening");
			GetComponent<Animator>().SetBool("idleClosed", false);
			GetComponent<Animator>().SetBool("idleOpened", true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (exit)
		{
			Debug.Log("Exited");
			openGate.enabled = false;
		}
	}
}
