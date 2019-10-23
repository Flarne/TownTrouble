using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] Canvas inventoryCanvas;
	[SerializeField] Canvas reticleCanvas;

	public bool toggleOnOff = false;

	void Start()
    {
		inventoryCanvas.enabled = false;
    }

	public void ToggleInventory()
	{
		if (Input.GetKeyDown(KeyCode.I) && toggleOnOff == false && Time.timeScale == 1)
		{
			Time.timeScale = 0;
			inventoryCanvas.enabled = true;
			reticleCanvas.enabled = false;
			toggleOnOff = true;
			Cursor.visible = true;
		}
		else if (Input.GetKeyDown(KeyCode.I) && toggleOnOff == true && Time.timeScale == 0)
		{
			Time.timeScale = 1;
			inventoryCanvas.enabled = false;
			reticleCanvas.enabled = true;
			toggleOnOff = false;
			Cursor.visible = false;
		}
		else
		{
			
		}
	}
}
