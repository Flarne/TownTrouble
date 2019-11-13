using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoss : MonoBehaviour
{
	[SerializeField] GameObject[] bossLoot;

	Transform enemyPosition;

	private int lootItemNumber;

	private void Start()
	{
		enemyPosition = GetComponent<Transform>();
	}

	public void BossLoot()
	{
		if (gameObject.tag == "Bockstensmannen")
		{
			lootItemNumber = 0;
			Instantiate(bossLoot[lootItemNumber], enemyPosition.position, Quaternion.identity);
		}
	}
}
