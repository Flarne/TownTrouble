﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] Camera fpCamera;
	[SerializeField] float shootRange = 100f;
	[SerializeField] float damage = 10f;
	[SerializeField] ParticleSystem muzzleFX;
	[SerializeField] GameObject impactHitFX;
	[SerializeField] Ammo ammoSlot;
	[SerializeField] float timeBetweenShoots = 0.5f;

	bool canShoot = true;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			StartCoroutine(Shoot());
		}
	}

	IEnumerator Shoot()
	{
		if (ammoSlot.CurrentAmountAmmo() > 0 && canShoot == true)
		{
			PlayMuzzleFX();
			ProcessRaycast();
			ammoSlot.AmmoDecrease();
			canShoot = false;
			yield return new WaitForSeconds(timeBetweenShoots);
			canShoot = true;
		}
	}

	private void PlayMuzzleFX()
	{
		muzzleFX.Play();
	}

	private void ProcessRaycast()
	{
		RaycastHit hit;
		if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, shootRange))
		{
			CreateHitImpact(hit); // makes FX on hits
			EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
			if (target == null) // Prevent from missing and hits something else
			{
				return;
			}
			target.TakeDamage(damage); // Call a method from EnemyHealth That decrease health
		}
		else
		{
			return;
		}
	}

	private void CreateHitImpact(RaycastHit hit)
	{
		GameObject impact = Instantiate(impactHitFX, hit.point, Quaternion.LookRotation(hit.normal));
		Destroy(impact, 0.1f);
	}
}
