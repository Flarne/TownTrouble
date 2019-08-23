using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField] AmmoSlot[] ammoSlots;

	[System.Serializable]
	private class AmmoSlot
	{
		public AmmoType ammotype;
		public int ammoAmount;
	}

	public int CurrentAmountAmmo(AmmoType ammoType)
	{
		return GetAmmoSlot(ammoType).ammoAmount;
	}

	public void AmmoDecrease(AmmoType ammoType)
	{
		GetAmmoSlot(ammoType).ammoAmount--;
	}

	//public void AmmoIncrease(AmmoType ammoType, int myAmmo)
	//{
	//	Debug.Log("Test");
	//	GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount + myAmmo;
	//}

	private AmmoSlot GetAmmoSlot(AmmoType ammoType)
	{
		foreach (AmmoSlot slot in ammoSlots)
		{
			if (slot.ammotype == ammoType)
			{
				return slot;
			}
		}
		return null;
	}
}
