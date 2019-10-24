using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNightLights : MonoBehaviour
{
	public static Component toggleStreetLights;
	//public DayAndNightCycle dayAndNightCycle;

	void Start()
	{
		toggleStreetLights = GetComponent<Component>();
		//toggleStreetLights.SetActive(true);
	}

	void Update()
	{
		NightOrDayLights();
	}

	public static void NightOrDayLights()
	{
		//if (DayAndNightCycle.currentTimeOfDay <= 0.27f || DayAndNightCycle.currentTimeOfDay >= 0.73f)
		//{
		if (DayAndNightCycle.streetLightOnOff == true)
		{
			Debug.Log("ja");
			toggleStreetLights.gameObject.SetActive(true);
		}
		//}
		//else if (DayAndNightCycle.currentTimeOfDay > 0.27f || DayAndNightCycle.currentTimeOfDay < 0.73f)
		//{
		else if (DayAndNightCycle.streetLightOnOff == false)
		{
			Debug.Log("nej");
			toggleStreetLights.gameObject.SetActive(false);
		}
	}
}
