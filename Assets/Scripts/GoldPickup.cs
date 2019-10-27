using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
	[SerializeField] int goldPickup = 10;
	[SerializeField] int minGoldPickup = 1;
	[SerializeField] int maxGolPickup = 20;

	private void Start()
	{
		goldPickup = Random.Range(minGoldPickup, maxGolPickup);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GoldText.goldAmount += goldPickup;
			Destroy(gameObject);
		}
	}
}
