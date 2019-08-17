using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] float hitpoints = 100f;

	// Create a public method that reduces hitpoints by the amount of damage
	public void TakeDamage(float damage)
	{
		hitpoints = hitpoints - damage;
		if (hitpoints <= 0)
		{
			Destroy(gameObject);
		}
	}
}
