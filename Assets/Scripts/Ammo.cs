using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField] int ammoAmount = 10;

	public int CurrentAmountAmmo()
	{
		return ammoAmount;
	}

	public void AmmoDecrease ()
	{
		ammoAmount--;
	}

	public void AmmoIncrease (int myAmmo)
	{
		ammoAmount = ammoAmount + myAmmo;
	}
}
