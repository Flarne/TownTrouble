using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNightLights : MonoBehaviour
{
	public GameObject toggleStreetLights;
	Transform result;

	void Start()
	{
		toggleStreetLights = GameObject.Find("/RoadLight");
	}

	void Update()
	{
		NightOrDayLights();
	}

	// This function checks every RoadLights in scene and turns off during day and turns on during night
	public void NightOrDayLights()
	{
		foreach (Transform lights in transform)
		{
			if (DayAndNightCycle.streetLightOnOff == true)
			{
				lights.gameObject.SetActive(true);
			}
			else if (DayAndNightCycle.streetLightOnOff == false)
			{
				lights.gameObject.SetActive(false);
			}
		}
	}
}
