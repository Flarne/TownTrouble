using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateRight : MonoBehaviour
{
	[SerializeField] Animator openGateRight;

	public bool enterRight = true;

	void Start()
	{
		openGateRight = GetComponent<Animator>();
		openGateRight.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (enterRight)
		{
			openGateRight.enabled = true;
			Debug.Log("entered Right");
			openGateRight.SetBool("openingRight", true);
			openGateRight.SetBool("openedRight", true);
		}
	}
}
