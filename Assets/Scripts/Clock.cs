using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
	public TextMeshProUGUI timeTextHour;
	public TextMeshProUGUI timeTextMinute;
	public TextMeshProUGUI timeTextSecond;

	float hoursToDegrees = 360f / 12f;
	float minutesToDegrees = 360f / 60f;
	float secondsToDegrees = 360f / 60f;

	// For RealTime
	const float degreesPerHour = 30f;
	const float degreesPerMinut = 6f;
	const float degreesPerSecond = 6f;

	public Transform hoursTransform;
	public Transform minutsTransform;
	public Transform secondsTransform;

	public bool continuous;

	void Start()
	{
		//timeText = GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{
		if (continuous)
		{
			UpdateContinuous();
		}
		else
		{
			UpdateDiscrete();
		}
	}

	// Makes clockarms move smoothly
	private void UpdateContinuous()
	{
		float currentHour = 24 * DayAndNightCycle.currentTimeOfDay;
		float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));
		float currentSecond = 60 * (currentMinute - Mathf.Floor(currentMinute));
		hoursTransform.localRotation = Quaternion.Euler(0f , currentHour * hoursToDegrees, 0f);
		minutsTransform.localRotation = Quaternion.Euler(0f, currentMinute * minutesToDegrees, 0f);
		secondsTransform.localRotation = Quaternion.Euler(0f, currentSecond * secondsToDegrees, 0f);
		timeTextHour.text = ((int)currentHour + ":").ToString();
		timeTextMinute.text = ((int)currentMinute + ":").ToString();
		timeTextSecond.text = ((int)currentSecond).ToString();

		// OutCommented cude shows realtime
		//TimeSpan time = DateTime.Now.TimeOfDay;
		//hoursTransform.localRotation = Quaternion.Euler(0f, (float)time * degreesPerHour, 0f);
		//minutsTransform.localRotation = Quaternion.Euler(0f, (float)time * degreesPerMinut, 0f);
		//secondsTransform.localRotation = Quaternion.Euler(0f, (float)time * degreesPerSecond, 0f);
	}

	// Makes clockarms move not smothly
	private void UpdateDiscrete()
	{
		float currentHour = 24 * DayAndNightCycle.currentTimeOfDay;
		float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));
		hoursTransform.localRotation = Quaternion.Euler(currentHour * hoursToDegrees, 0, 0);
		minutsTransform.localRotation = Quaternion.Euler(currentMinute * minutesToDegrees, 0, 0);

		// OutCommented cude shows realtime
		//DateTime time = DateTime.Now;
		//hoursTransform.localRotation = Quaternion.Euler(0f, time * degreesPerHour, 0f);
		//minutsTransform.localRotation = Quaternion.Euler(0f, time * degreesPerMinut, 0f);
		//secondsTransform.localRotation = Quaternion.Euler(0f, time * degreesPerSecond, 0f);
	}
}
