using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float playerDamage = 100f;
	
    public void PlayerTakeDamage(float damageIn)
	{
		playerDamage -= damageIn;
		if (playerDamage <= 0)
		{
			Debug.Log("You are DEAD, Looser");
		}
	}
}
