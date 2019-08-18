using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
	[SerializeField] Camera fpsCamera;
	[SerializeField] float zoomIn = 60f;
	[SerializeField] float zoomOut = 20f;

	bool zoomedInToggle = false;
	
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
		{
			if (zoomedInToggle == false)
			{
				zoomedInToggle = true;
				fpsCamera.fieldOfView = zoomIn;
			}
			else
			{
				zoomedInToggle = false;
				fpsCamera.fieldOfView = zoomOut;
			}
		}
    }
}
