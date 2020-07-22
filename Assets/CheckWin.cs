using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CheckWin : MonoBehaviour
{

	public Sprite[] sprites;
	public Button leiter;
	public Text txtMoney;
	public Text txtBet;
	public Text txtWin;




	// Start is called before the first frame update
	void Start()
    {
		PlayerInfo.money = 500;
		PlayerInfo.bet = 10;
		PlayerInfo.winning = 0;
    }

	public void check1()
	{

		Invoke("Check", 0);
	}


	public void StartClick()
	{
		 PlayerInfo.money -= PlayerInfo.bet;
	}

	public void Switch()
	{
		SceneManager.LoadScene("Leiter");
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

		#region Zu Viel IFs
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
		#endregion

		if (jackpot_counter == 5)
		{
			//RAD HIER
		}
		if (oneWin)
		{
			PlayerInfo.money += PlayerInfo.winning;
			Debug.Log("EIN GEWINN!!!!!!");
			leiter.gameObject.SetActive(true);
			txtWin.text = PlayerInfo.winning.ToString();
			PlayerInfo.winning = 0;
		}


		UpdateNumbers();


	}


	

	private void calcWin(int item)
	{
		switch (item)
		{
			case 0:
				PlayerInfo.winning += PlayerInfo.bet * 2;
				break;
			case 1:
				PlayerInfo.winning += PlayerInfo.bet * 4;
				break;
			case 2:
				PlayerInfo.winning += PlayerInfo.bet * 6;
				break;

			default:
				break;
		}
	}


	private void UpdateNumbers()
	{
		txtMoney.text = PlayerInfo.money.ToString();
		txtBet.text = PlayerInfo.bet.ToString();
		
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
