using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	[SerializeField] Animator openGate;
	//[SerializeField] Animator openGateRight;

	public bool enter = true;
	//public bool enterRight = true;
	public bool exit = true;
	float smooth = 5.0f;

	private void Start()
	{
		openGate = GetComponent<Animator>();
		//openGateRight = GetComponent<Animator>();
		openGate.enabled = false;
		//openGateRight.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (enter)
		{
			openGate.enabled = true;
			Debug.Log("entered");
			openGate.SetBool("opening", true);
			openGate.SetBool("opened", true);
		}

		//if (enterRight)
		//{
		//	openGateRight.enabled = true;
		//	Debug.Log("entered Right");
		//	openGateRight.SetBool("openingRight", true);
		//	openGateRight.SetBool("openedRight", true);
		//}
	}

			//animator.enabled = true;
			//animator.SetBool("open", true);
			//animator.SetBool("opened", true);

	private void OnTriggerExit(Collider other)
	{
		if (exit)
		{
			Debug.Log("Exited");
			//openGate.enabled = false;
		}
	}
}
