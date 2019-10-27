using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
	[SerializeField] GameObject[] lootList;

	private Transform enemyPosition;

	private int lootItemNumber;
	private int controlLootNumber;
	const int minLootNumber = 1;
	const int maxLootNumber = 100;

	private void Start()
	{
		enemyPosition = GetComponent<Transform>();
		controlLootNumber = Random.Range(minLootNumber, maxLootNumber);
	}

	// Makes random drop for loot (goldcoins, gunbullets, shotgunshells, sniper bullets)
	public void LootRandomizer()
	{
		if (controlLootNumber > 20 && controlLootNumber <= 55)
		{
			lootItemNumber = 3;
			Instantiate(lootList[lootItemNumber], enemyPosition.position, Quaternion.identity);
			lootItemNumber = 2;
			Instantiate(lootList[lootItemNumber], enemyPosition.position, Quaternion.identity);
		}
		else if (controlLootNumber > 55 && controlLootNumber <= 75)
		{
			lootItemNumber = 2;
			Instantiate(lootList[lootItemNumber], enemyPosition.position, Quaternion.identity);
		}
		else if (controlLootNumber > 75 && controlLootNumber <= 87)
		{
			lootItemNumber = 1;
			Instantiate(lootList[lootItemNumber], enemyPosition.position, Quaternion.identity);
		}
		else if (controlLootNumber > 88)
		{
			lootItemNumber = 0;
			Instantiate(lootList[lootItemNumber], enemyPosition.position, Quaternion.identity);
		}

	}
}
