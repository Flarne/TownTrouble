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
	[SerializeField] float mouseZoomOut = 3f;
	[SerializeField] float mouseZoomIn = 2f;

	public static bool zoomedInToggle = false;

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
		if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			return;
		}
		else
		{
			zoomedInToggle = true;
			fpsCamera.fieldOfView = zoomIn;
			fpsController.mouseLook.XSensitivity = mouseZoomIn;
			fpsController.mouseLook.YSensitivity = mouseZoomIn;
		}
	}

	private void ZoomOut()
	{
		zoomedInToggle = false;
		fpsCamera.fieldOfView = zoomOut;
		fpsController.mouseLook.XSensitivity = mouseZoomOut;
		fpsController.mouseLook.YSensitivity = mouseZoomOut;
	}
}
