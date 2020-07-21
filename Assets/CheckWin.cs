using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CheckWin : MonoBehaviour
{

	public Sprite[] sprites;
	public int money;
	public int bet;
	public int winning;

	// Start is called before the first frame update
	void Start()
    {
		money = 500;
		bet = 10;
		winning = 0;
    }

	public void check1()
	{

		Invoke("Check", 0);
	}


	public void StartClick()
	{
		money -= bet;
	}


	public void Check()
	{
		int[,] result = new int[3, 3];


		for (int j = 0; j < 3; j++)
		{
			for (int i = 0; i < 3; i++)
			{
				result[j,i] = Random.Range(0, 3);
				GameObject.Find(j.ToString()+i.ToString()).GetComponent<Image>().sprite = sprites[result[j,i]];
			}
		}
		int jackpot_counter = 0;
		bool oneWin = false;
		if (result[0, 0] == result[0, 1] && result[0, 1] == result[0, 2])
		{
			calcWin(result[0, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if(result[1, 0] == result[1, 1] && result[1, 1] == result[1, 2])
		{
			calcWin(result[1,0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (result[2, 0] == result[2, 1] && result[2, 1] == result[2, 2])
		{
			calcWin(result[2, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (result[0, 0] == result[1, 1] && result[1, 1] == result[2, 2])
		{
			calcWin(result[0, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (result[2, 0] == result[1, 1] && result[1, 1] == result[0, 2])
		{
			calcWin(result[2, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (jackpot_counter == 5)
		{
			//RAD HIER
		}
		if (oneWin)
		{
			money += winning;
			Debug.Log("EIN GEWINN!!!!!!");
		}


		UpdateNumbers();


	}

	private void calcWin(int item)
	{
		switch (item)
		{
			case 0:
				winning += bet * 2;
				break;
			case 1:
				winning += bet * 4;
				break;
			case 2:
				winning += bet * 6;
				break;

			default:
				break;
		}
	}


	private void UpdateNumbers()
	{
		
		GameObject.Find("txtMoney").GetComponent<Text>().text = money.ToString();
		GameObject.Find("txtBet").GetComponent<Text>().text = bet.ToString();
		GameObject.Find("txtWin").GetComponent<Text>().text = winning.ToString();
		
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
