using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] Camera fpCamera;
	[SerializeField] float shootRange = 100f;
	[SerializeField] int damage = 10;
	[SerializeField] int minDamage = 10;
	[SerializeField] int maxDamage = 10;
	[SerializeField] ParticleSystem muzzleFX;
	[SerializeField] GameObject impactHitFX;
	[SerializeField] Ammo ammoSlot;
	[SerializeField] AmmoType ammoType;
	[SerializeField] float timeBetweenShoots = 0.5f;

	public static bool canShoot = true;
	public static float shootTimer;

	private void Start()
	{
		damage = UnityEngine.Random.Range(minDamage, maxDamage);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			
			shootTimer = timeBetweenShoots;
			StartCoroutine(Shoot());
		}
	}

	public IEnumerator Shoot()
	{
		if (ammoSlot.CurrentAmountAmmo(ammoType) > 0 && canShoot == true)
		{
			PlayMuzzleFX();
			ProcessRaycast();
			ammoSlot.AmmoDecrease(ammoType);
			canShoot = false;
			yield return new WaitForSeconds(shootTimer);
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
			damage = UnityEngine.Random.Range(minDamage, maxDamage);
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
