using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	[SerializeField] Animator openGate;

	public bool enter = true;
	bool isAnimating = false;
	public bool exit = true;
	public float gateTime;

	private void Start()
	{
		openGate = GetComponent<Animator>();
		openGate.enabled = false;
	}

	private void Update()
	{
		gateTime += Time.deltaTime;

		if (gateTime <= 10f)
		{
			isAnimating = false;
			return;
		}
		else if (gateTime > 10f || gateTime < 12f)
		{
			openGate.enabled = false;
			isAnimating = true;
			gateTime = 0f;
		}
		if (openGate.enabled == false)
		{
			isAnimating = true;
			gateTime = 0f;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		gateTime = 0f;
		if (enter && gateTime <= 10f && !isAnimating && other.gameObject.tag == "Player")
		{
			openGate.enabled = true;
			openGate.SetTrigger("openingTriggerRight");
			openGate.SetTrigger("openingTrigger");
			openGate.SetBool("openedRight", true);
			openGate.SetBool("opened", true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (exit && gateTime <= 10f && !isAnimating && other.gameObject.tag == "Player")
		{
			gateTime = 0f;
			openGate.enabled = true;
			openGate.SetTrigger("closingTriggerRight");
			openGate.SetTrigger("closingTrigger");
			openGate.SetBool("closedRight", true);
			openGate.SetBool("closed", true);
		}
	}
}
