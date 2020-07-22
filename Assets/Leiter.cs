using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Leiter : MonoBehaviour
{



	private int position;
	private bool schalter;
	private int c;
	private List<int> price;
	private protected int[] multipliaktoren = new int[] { 0, 2, 5, 7, 10, 20, 40, 70, 100, 200 };

	// Start is called before the first frame update
	void Start()
	{
		
		SetPrice();
		SetButtons();
		position = GetPostion();

		schalter = true;
		GameObject.Find("box" + position).GetComponent<Image>().color = Color.green;
	}


	private void SetPrice()
	{
		price = new List<int>();

		for (int i = 0; i < 10; i++)
		{
			price[i] = multipliaktoren[i] * PlayerInfo.bet;
		}

	}
	private void SetButtons()
	{
		for (int i = 0; i < 10; i++)
		{
			Debug.Log(i + 1);
			GameObject.Find("txt" + (i+1)).GetComponent<Text>().text = price[i].ToString();
		}
	}

	private int GetPostion()
	{
		if (price.Contains(PlayerInfo.winning))
		{
			return price.IndexOf(PlayerInfo.winning);
		}

		for (int i = 0; i < 10; i++)
		{
			if (PlayerInfo.winning > price[i] && PlayerInfo.winning < price[i])
			{

			}
		}




		return 4;
	}


	public void Start_click()
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

	public void End_click()
	{


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
