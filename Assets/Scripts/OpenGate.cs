using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
	[SerializeField] Animator openGate;

	public bool enter = true;
	bool isAnimating = false;
	//public bool enterRight = true;
	public bool exit = true;
	public float gateTime;
	float smooth = 5.0f;

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

	public IEnumerator toggleOnOffAnimator()
	{
		yield return new WaitForSeconds(4f);
		openGate.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		gateTime = 0f;
		//if (enter && isAnimating && gateTime >= 0 || gateTime <= 5)
		if (enter && gateTime <= 10f && !isAnimating)
		{
			openGate.enabled = true;
			//isAnimating = true;
			openGate.SetTrigger("openingTriggerRight");
			openGate.SetBool("openedRight", true);
			//openGate.SetBool("closing", false);
			//openGate.SetBool("closingRight", false);
			//openGate.SetBool("opening", true);
			//openGate.SetBool("opened", true);
			//openGate.SetBool("openingRight", true);

			//if (gateTime <= 5f && isAnimating)
			//{
			//	return;
			//}
			//else if (gateTime > 5f)
			//{
			//	Debug.Log(isAnimating);
			//}

			//else if (!isAnimating && gateTime > 5f)
			//{
			//	gateTime = 0f;
			//	isAnimating = true;
			//	openGate.enabled = false;
			//}
		}

		//if (enterRight)
		//{
		//	openGate.enabled = true;
		//	Debug.Log("entered Right");
		//	openGate.SetBool("openingRight", true);
		//	openGate.SetBool("openedRight", true);
		//}
	}

	private void OnTriggerExit(Collider other)
	{
		//if (exit && gateTime >= 0 || gateTime <= 5)
		if (exit && gateTime <= 10f && !isAnimating)
		{
			gateTime = 0f;
			openGate.enabled = true;
			//isAnimating = true;
			openGate.SetTrigger("closingTriggerRight");
			openGate.SetBool("closedRight", true);
			//openGate.SetBool("closingRight", true);
			//openGate.SetBool("openedRight", false);
			//openGate.SetBool("openingRight", false);
			//openGate.SetBool("closing", true);
			//openGate.SetBool("closed", true);
			//openGate.SetBool("opening", false);

			//if (gateTime <= 5f && isAnimating)
			//{
			//	return;
			//}
			//else if (gateTime > 5f)
			//{
			//	isAnimating = false;
			//	Debug.Log(isAnimating);
			//}
			//else if (!isAnimating && gateTime > 5f)
			//{
			//	gateTime = 0f;
			//	isAnimating = true;
			//	//openGate.enabled = false;
			//}
			//StartCoroutine(toggleOnOffAnimator());
		}
	}
}
