using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float playerDamage = 100f;

	public TextMeshProUGUI healthText;

	private void Start()
	{
		healthText.text = playerDamage.ToString();
	}

	public void PlayerTakeDamage(float damageIn)
	{
		playerDamage -= damageIn;
		healthText.text = playerDamage.ToString();
		if (playerDamage <= 0)
		{
			DeathHandler deathHandler = GetComponent<DeathHandler>();
			deathHandler.HandleDeath();
		}
	}
}
