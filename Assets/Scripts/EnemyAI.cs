using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] float chaseRange = 10f;
	[SerializeField] float turnSpeed = 5f;

	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;

	EnemyHealth enemyHealth;

	public bool isProvoked = false;
	bool isDead = false;
	
    void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		enemyHealth = GetComponent<EnemyHealth>();
	}
	
    void Update()
	{
		// When Zombie is dead turn off movement and nav seeking and jumps over code below in Update
		if (enemyHealth.IsDead())
		{
			enabled = false;
			navMeshAgent.enabled = false;
			isDead = true;
		}

		// If Zombie is provoked he starts to chase you or else when you get to close to the zombie
		distanceToTarget = Vector3.Distance(target.position, transform.position);

		// Zombie attacks only during night time and is spawned. In daytime player can run around 
		// and don't have alot of zombies chasing player when it is dark again.
		if (isProvoked && DayAndNightCycle.streetLightOnOff == true)
		{
			EngageTarget();
		}
		else if (distanceToTarget <= chaseRange && DayAndNightCycle.streetLightOnOff == true)
		{
			isProvoked = true;
		}
    }

	public void OnDamageTaken()
	{
		isProvoked = true;
	}

	private void EngageTarget()
	{
		FaceTarget();
		if (distanceToTarget >= navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}

		if (distanceToTarget <= navMeshAgent.stoppingDistance)
		{
			AttackTarget();
		}
	}

	private void ChaseTarget()
	{
		if (isDead) return;

		if (DayAndNightCycle.streetLightOnOff == true)
		{
			GetComponent<Animator>().SetBool("attack", false);
			GetComponent<Animator>().SetTrigger("move");
			navMeshAgent.SetDestination(target.position);
		}
		else if (DayAndNightCycle.streetLightOnOff == false)
		{
			GetComponent<Animator>().SetTrigger("idle");
		}
		
	}

	// When zombie is close enough animation starts to hit you
	private void AttackTarget()
	{
		GetComponent<Animator>().SetBool("attack", true);
	}

	private void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1, 0, 0, 0.75f);
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}
