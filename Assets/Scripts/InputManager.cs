using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField] Inventory inventory;
	[SerializeField] ToggleFlashLight flashLight;
	
    void Update()
    {
		inventory.ToggleInventory();
		flashLight.FlashLightToggleOnOff();
    }
}
