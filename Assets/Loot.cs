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
		Debug.Log(controlLootNumber);
		if (controlLootNumber >= 50 && controlLootNumber < 75)
		{
			GameObject loot = Instantiate(ammoLoot, transform.position, transform.rotation);
			Debug.Log(loot);
		}
		else if (controlLootNumber >= 75 && controlLootNumber <= 100)
		{
			GameObject loot = Instantiate(goldLoot, transform.position, transform.rotation);
			Debug.Log(loot);
		}

	}
}
