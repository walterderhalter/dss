using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Leiter : MonoBehaviour
{
	public int Money;
	public int Win;


	private int position;
	private bool schalter;
	private int c;

	// Start is called before the first frame update
	void Start()
	{
		position = 4;
		schalter = true;
		GameObject.Find("box" + position).GetComponent<Image>().color = Color.green;
	}



	public void Drück()
	{
		int rnd_int = Random.Range(0, 10);
		GameObject.Find("box" + (position + 1)).GetComponent<Image>().color = Color.white;
		GameObject.Find("box" + (position - 1)).GetComponent<Image>().color = Color.white;
		GameObject.Find("box" + position).GetComponent<Image>().color = Color.white;
		if (rnd_int <= 3)
		{
			position++;
		}
		else if (rnd_int >= 4)
		{
			position--;
		}
		GameObject.Find("box" + position).GetComponent<Image>().color = Color.green;

	}

	// Update is called once per frame
	void Update()
	{
		if (position - 1 < 1)
		{
			enabled = false;
		}
		else
		{
			if (schalter)
			{
				GameObject.Find("box" + (position + 1)).GetComponent<Image>().color = Color.red;
				GameObject.Find("box" + (position - 1)).GetComponent<Image>().color = Color.white;
				c++;
			}
			else
			{
				GameObject.Find("box" + (position + 1)).GetComponent<Image>().color = Color.white;
				GameObject.Find("box" + (position - 1)).GetComponent<Image>().color = Color.red;
				c++;
			}

			if (c == 15)
			{
				schalter = !schalter;
				c = 0;
			}
		}
	}
}
