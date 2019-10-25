using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
	[SerializeField] GameObject ammoLoot;
	[SerializeField] GameObject goldLoot;

	private int controlLootNumber;
	const int minLootNumber = 1;
	const int maxLootNumber = 100;

	private void Start()
	{
		ammoLoot = GetComponent<GameObject>();
		goldLoot = GetComponent<GameObject>();
		controlLootNumber = Random.Range(minLootNumber, maxLootNumber);
	}

	public void LootRandomizer()
	{
		if (controlLootNumber < 50)
		{
			return;
		}
		else if (controlLootNumber < 75)
		{
			Instantiate(ammoLoot, transform.position, transform.rotation);
		}
		else
		{
			Instantiate(goldLoot, transform.position, transform.rotation);
		}

	}
}
