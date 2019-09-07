using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
	[SerializeField] Camera fpsCamera;
	[SerializeField] RigidbodyFirstPersonController fpsController;
	[SerializeField] float zoomIn = 60f;
	[SerializeField] float zoomOut = 20f;
	[SerializeField] float mouseZoomOut = 2f;
	[SerializeField] float mouseZoomIn = 0.5f;

	bool zoomedInToggle = false;

	void OnDisable()
	{
		ZoomIn();
	}

	private void Update()
    {

		if (Input.GetMouseButtonDown(1))
		{
			if (zoomedInToggle == false)
			{
				ZoomIn();
			}
			else
			{
				ZoomOut();
			}
		}
    }

	private void ZoomIn()
	{
		zoomedInToggle = true;
		fpsCamera.fieldOfView = zoomIn;
		fpsController.mouseLook.XSensitivity = mouseZoomIn;
		fpsController.mouseLook.YSensitivity = mouseZoomIn;
	}

	private void ZoomOut()
	{
		zoomedInToggle = false;
		fpsCamera.fieldOfView = zoomOut;
		fpsController.mouseLook.XSensitivity = mouseZoomOut;
		fpsController.mouseLook.YSensitivity = mouseZoomOut;
	}
}
