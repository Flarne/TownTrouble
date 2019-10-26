using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	PlayerHealth target;

	[SerializeField] int bigMedPac = 50;
	[SerializeField] int mediumMedPac = 30;
	[SerializeField] int smallMedPac = 10;

	public int myPlayerHitPoints;

	private void Start()
	{
		target = FindObjectOfType<PlayerHealth>();
		myPlayerHitPoints = PlayerHealth.playerDamage;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (PlayerHealth.playerDamage >= 200)
			{
				PlayerHealth.playerDamage = 200;
				return;
			}
			target.PlayerIncreaseHealth(bigMedPac);
			Destroy(gameObject);
		}
	}
}
