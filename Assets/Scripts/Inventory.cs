using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour
{
	//MouseLook mouseLook;
	[SerializeField] Canvas inventoryCanvas;
	[SerializeField] Canvas reticleCanvas;

	public bool toggleOnOff = false;

	void Start()
    {
		//mouseLook = GetComponent<MouseLook>();
		inventoryCanvas.enabled = false;
    }

	public void ToggleInventory()
	{
		if (Input.GetKeyDown(KeyCode.I) && toggleOnOff == false && Time.timeScale == 1 && MouseLook.m_cursorIsLocked == true)
		{
			Time.timeScale = 0;
			Weapon.canShoot = false;
			inventoryCanvas.enabled = true;
			reticleCanvas.enabled = false;
			toggleOnOff = true;
			MouseLook.m_cursorIsLocked = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else if (Input.GetKeyDown(KeyCode.I) && toggleOnOff == true && Time.timeScale == 0 && MouseLook.m_cursorIsLocked == false)
		{
			Time.timeScale = 1;
			Weapon.canShoot = true;
			inventoryCanvas.enabled = false;
			reticleCanvas.enabled = true;
			toggleOnOff = false;
			MouseLook.m_cursorIsLocked = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			
		}
	}
}
