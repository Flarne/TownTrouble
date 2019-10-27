using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI goldText;
	public static int goldAmount = 50;

	void Start()
	{
		goldText = GetComponent<TextMeshProUGUI>();
		goldText.text = goldAmount.ToString();
	}
	
    void Update()
    {
		goldText.text = goldAmount.ToString();
	}
}
