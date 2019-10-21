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
		//flashLight.gameObject.SetActive(false);
    }

	private void Update()
	{
		FlashLightToggleOnOff();
	}

	public void FlashLightToggleOnOff ()
	{
		if (Input.GetKeyDown(KeyCode.L) && toggleOnOff == false)
		{
			Debug.Log(flashLight);
			flashLight.enabled = true;
			toggleOnOff = true;
		}
		else if (Input.GetKeyDown(KeyCode.L) && toggleOnOff == true)
		{
			Debug.Log(toggleOnOff);
			flashLight.enabled= false;
			toggleOnOff = false;
		}
	}
}
