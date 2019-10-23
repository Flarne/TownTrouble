using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFlashLight : MonoBehaviour
{
	[SerializeField] Light flashLight;

	public bool toggleOnOff = false;

    void Start()
    {
		flashLight = GetComponent<Light>();
    }

	public void FlashLightToggleOnOff ()
	{
		if (Input.GetKeyDown(KeyCode.L) && toggleOnOff == false)
		{
			flashLight.enabled = true;
			toggleOnOff = true;
		}
		else if (Input.GetKeyDown(KeyCode.L) && toggleOnOff == true)
		{
			flashLight.enabled= false;
			toggleOnOff = false;
		}
	}
}
