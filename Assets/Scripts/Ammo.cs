using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
	[SerializeField] AmmoSlot[] ammoSlots;
	
		public TextMeshProUGUI amountAmmunitionText;

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
		amountAmmunitionText.text = CurrentAmountAmmo(ammoType).ToString();
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
