﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] public static int playerDamage = 100;
	[SerializeField] public static int maxPlayerDamage = 200;

	public TextMeshProUGUI healthText;

	private void Start()
	{
		healthText.text = playerDamage.ToString();
	}

	public void PlayerTakeDamage(int damageIn)
	{
		playerDamage -= damageIn;
		healthText.text = playerDamage.ToString();
		if (playerDamage <= 0)
		{
			DeathHandler deathHandler = GetComponent<DeathHandler>();
			deathHandler.HandleDeath();
		}
	}

	public void PlayerIncreaseHealth(int healthIn)
	{
		playerDamage += healthIn;
		healthText.text = playerDamage.ToString();

		if (playerDamage >= 200)
		{
			healthText.text = playerDamage.ToString();
		}
		if (playerDamage > 200)
		{
			playerDamage = 200;
			healthText.text = maxPlayerDamage.ToString();
		}
	}
}
