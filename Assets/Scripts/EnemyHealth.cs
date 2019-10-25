using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	Loot lootTarget;

	[SerializeField] float hitpoints = 100f;

	bool isDead = false;

	private void Start()
	{
		lootTarget = FindObjectOfType<Loot>();
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
			lootTarget.LootRandomizer();
			Die();
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
