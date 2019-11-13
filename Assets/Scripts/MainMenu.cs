using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MainMenu : MonoBehaviour
{
	public void PlayTT()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("TT_Bockstensmannen");
		MouseLook.m_cursorIsLocked = true;
		PlayerHealth.playerDamage = 200;
		Weapon.canShoot = true;
	}

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void TryAgain()
	{
		SceneManager.LoadScene("TT_Bockstensmannen");
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
