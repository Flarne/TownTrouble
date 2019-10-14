﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
	[SerializeField] int currentWeapon = 0;
	public static float shootTimer;

    void Start()
    {
		WeaponZoom.zoomedInToggle = true;
		SetActiveWeapon();
	}

	void Update()
	{
		int previousWeapon = currentWeapon;

		ProcessKeyboardInput();
		ProcessScrollWheelInput();

		if (previousWeapon != currentWeapon)
		{
			SetActiveWeapon();
		}
	}

	private void ProcessKeyboardInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentWeapon = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentWeapon = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentWeapon = 2;
		}
		else
		{
			return;
		}
	}

	private void ProcessScrollWheelInput()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			if (currentWeapon >= transform.childCount - 1)
			{
				currentWeapon = 0;
			}
			else
			{
				currentWeapon++;
			}
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			if (currentWeapon <= 0)
			{
				currentWeapon = transform.childCount - 1;
			}
			else
			{
				currentWeapon--;
			}
		}
	}

	private void SetActiveWeapon()
	{
		int weaponIndex = 0;

		if (Weapon.canShoot == true && WeaponZoom.zoomedInToggle == true)
		{
			foreach (Transform weapon in transform)
			{
				if (weaponIndex == currentWeapon)
				{
					weapon.gameObject.SetActive(true);
					shootTimer = Weapon.shootTimer;
					//Debug.Log(shootTimer);
				}
				else if (weaponIndex != currentWeapon)
				{
					weapon.gameObject.SetActive(false);
				}
				weaponIndex++;
			}
		}
	}
}
