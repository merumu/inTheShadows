using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onOff : MonoBehaviour {
	
	public gameManager gm;
	public Text on;
	public Text shadows;
	private int s;

	void Start()
	{
		s = PlayerPrefs.GetInt("sound");
		if (s == 1)
		{
			on.text = "On";
			shadows.text = "On";
		}
		else
		{
			on.text = "Off";
			shadows.text = "Off";
		}
	}

	public void onToOff()
	{
		if (on.text == "On")
		{
			on.text = "Off";
			shadows.text = "Off";
		}
		else
		{
			on.text = "On";
			shadows.text = "On";
		}
	}
}
