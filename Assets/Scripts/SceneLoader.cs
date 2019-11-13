using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
	{
		SceneManager.LoadScene("Menu");
		if (Time.timeScale == 1 && MouseLook.m_cursorIsLocked == true)
		{
			Time.timeScale = 0;
			MouseLook.m_cursorIsLocked = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else if (Time.timeScale == 0 && MouseLook.m_cursorIsLocked == false)
		{
			Time.timeScale = 1;
			MouseLook.m_cursorIsLocked = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
