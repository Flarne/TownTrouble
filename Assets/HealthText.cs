using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
	PlayerHealth target;

	public static int healthAmount;

	void Start()
	{
		PlayerHealth.healthText = GetComponent<TextMeshProUGUI>();
    }
}
