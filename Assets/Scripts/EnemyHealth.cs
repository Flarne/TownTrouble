using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	private Loot getLoot;

	[SerializeField] float hitpoints = 100f;

	bool isDead = false;

	private void Start()
	{
		getLoot = GetComponent<Loot>();
	}

	public bool IsDead()
	{
		return isDead;
	}

	// Create a public method that reduces hitpoints by the amount of damage
	public void TakeDamage(float damage)
	{
		// GetComponent<EnemyAI>().OnDamageTaken(); // Alternative to BroadCastMessage() Can be conflicts
		BroadcastMessage("OnDamageTaken");
		hitpoints = hitpoints - damage;
		if (hitpoints <= 0)
		{
			LootDrop();
			Die();
		}
	}

	// gets funktion from Loot script when enemy is dead and return the right loot.
	void LootDrop ()
	{
		if (hitpoints <= 0)
		{
			if (getLoot != null)
			getLoot.LootRandomizer();
		}
	}

	private void Die()
	{
		if (isDead) return;
		isDead = true;

		GetComponent<Animator>().SetTrigger("die");
		Destroy(gameObject, 3f);
	}
}
