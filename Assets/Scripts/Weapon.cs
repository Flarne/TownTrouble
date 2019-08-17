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

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
			PlayMuzzleFX();
			Shoot();
		}
    }

	private void PlayMuzzleFX()
	{
		muzzleFX.Play();
	}

	private void Shoot()
	{
		ProcessRaycast();
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
