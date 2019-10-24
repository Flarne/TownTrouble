using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	PlayerHealth target;
	[SerializeField] int damage = 10;
	[SerializeField] int minDamage;
	[SerializeField] int maxDamage;


	void Start()
    {
		target = FindObjectOfType<PlayerHealth>();
		damage = Random.Range(minDamage, maxDamage);
    }

	public void AttackHitEvent()
	{
		damage = Random.Range(minDamage, maxDamage);
		if (target == null)
		{
			return;
		}
		target.PlayerTakeDamage(damage);
		Debug.Log(damage);
	}
}
