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
	public Button btn_Leiter;
	public Button btn_Start;
	public Text txtMoney;
	public Text txtBet;
	public Text txtWin;
	private bool oneWin = false;
	private int[] bets = new int[5] { 10, 20, 50, 100, 200 };
	private int betIndex = 0;




	// Start is called before the first frame update
	void Start()
    {
		UpdateNumbers();
    }




	public void StartClick()
	{
		if (oneWin)
		{
			PlayerInfo.money += PlayerInfo.winning - PlayerInfo.bet;
			UpdateNumbers();
			PlayerInfo.winning = 0;
			oneWin = false;

		}
		else
		{
			PlayerInfo.money -= PlayerInfo.bet;
			UpdateNumbers();
		}
		btn_Start.gameObject.SetActive(false);
		Invoke("Check", 2);
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
				result[j,i] = Random.Range(0, 6);
				GameObject.Find(j.ToString()+i.ToString()).GetComponent<Image>().sprite = sprites[result[j,i]];
			}
			
		}



		int jackpot_counter = 0;
		#region Zu Viel IFs
		#region Bitte lass es zu, des is echt peinlich 
		if (result[0, 0] == result[0, 1] && result[0, 1] == result[0, 2]&&result[0,0]!=0)
		{
			CalcWin(result[0, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if(result[1, 0] == result[1, 1] && result[1, 1] == result[1, 2] && result[1, 0] != 0)
		{
			CalcWin(result[1,0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (result[2, 0] == result[2, 1] && result[2, 1] == result[2, 2] && result[2, 0] != 0)
		{
			CalcWin(result[2, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (result[0, 0] == result[1, 1] && result[1, 1] == result[2, 2] && result[0, 0] != 0)
		{
			CalcWin(result[0, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		if (result[2, 0] == result[1, 1] && result[1, 1] == result[0, 2] && result[2, 0] != 0)
		{
			CalcWin(result[2, 0]);
			oneWin = true;
			jackpot_counter++;
		}
		#endregion
		#endregion

		if (jackpot_counter == 5)
		{
			//RAD HIER
		}
		//Hier könnte man oneWin und jackpotcounter zusammen legen und sich ein If sparen
		if (oneWin)
		{
			Debug.Log("EIN GEWINN!!!!!!" + PlayerInfo.winning);
			btn_Leiter.gameObject.SetActive(true);
			txtWin.text = PlayerInfo.winning.ToString();
		}

		UpdateNumbers();
		btn_Start.gameObject.SetActive(true);

	}


	public void SwitchBet()
	{
		betIndex++;
		Debug.Log(betIndex);
		if (betIndex >= bets.Length) betIndex = 0;
		PlayerInfo.bet = bets[betIndex];
		txtBet.text = PlayerInfo.bet.ToString();
		Debug.Log(txtBet.text);
	}
	

	private void CalcWin(int item)
	{
		switch (item)
		{
			case 0:
				break;
			case 1:
				PlayerInfo.winning += PlayerInfo.bet * 2;
				break;
			case 2:
				PlayerInfo.winning += PlayerInfo.bet * 3;
				break;
			case 3:
				PlayerInfo.winning += PlayerInfo.bet * 5;
				break;
			case 4:
				PlayerInfo.winning += PlayerInfo.bet * 10;
				break;
			case 5:
				PlayerInfo.winning += PlayerInfo.bet * 15;
				break;

			default:
				break;
		}
	}


	

	private void UpdateNumbers()
	{
		txtMoney.text = PlayerInfo.money.ToString();
		txtBet.text = PlayerInfo.bet.ToString();
		txtWin.text = PlayerInfo.winning.ToString();
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
