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

	// In here we get Value from AmmoPickup and add to get more ammo for that ammo you picked up
	public void AmmoPickup(AmmoType ammoType, int ammoAmount)
	{
		GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
	}

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
