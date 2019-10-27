using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnemySpawn : MonoBehaviour
{
	public GameObject toggleEnemies;

	void Start()
	{
		toggleEnemies = GameObject.Find("Enemies");
	}

	private void Update()
	{
		EnemySpawn();
	}

	public void EnemySpawn()
	{
		foreach (Transform enemies in transform)
		{
			if (DayAndNightCycle.streetLightOnOff == true)
			{
				enemies.gameObject.SetActive(true);
			}
			else if (DayAndNightCycle.streetLightOnOff == false)
			{
				enemies.gameObject.SetActive(false);
			}
		}
	}
}
