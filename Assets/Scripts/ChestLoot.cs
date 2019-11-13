using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLoot : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] GameObject[] bossLoot;

	private Transform chestTransform;

	private int lootItemNumber;

	private bool opened = false;

	private void Start()
	{
		animator = GetComponent<Animator>();
		chestTransform = GetComponent<Transform>();
		animator.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!opened)
		{
			animator.enabled = true;
			animator.SetBool("open", true);
			animator.SetBool("opened", true);
			lootItemNumber = 0;
			Instantiate(bossLoot[lootItemNumber], chestTransform.position, Quaternion.identity);
		}
	}
}
