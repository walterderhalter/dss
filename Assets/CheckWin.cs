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
	public Button btn_Bet;
	public Text txtMoney;
	public Text txtBet;
	public Text txtWin;
	public SpriteRenderer[] lines;
	private bool oneWin = false;
	private int[] bets = new int[5] { 10, 20, 50, 100, 200 };
	private int betIndex = 0;




	// Start is called before the first frame update
	void Start()
    {
		UpdateNumbers();
		txtWin.text = PlayerInfo.winning.ToString();
	}





	public void StartClick()
	{
		if (oneWin)
		{
			PlayerInfo.money += PlayerInfo.winning - PlayerInfo.bet;
			txtWin.text = PlayerInfo.winning.ToString();
			UpdateNumbers();

			oneWin = false;
			for (int i = 0; i < lines.Length; i++)lines[i].gameObject.SetActive(false);


		}
		else
		{
			PlayerInfo.money -= PlayerInfo.bet;
			UpdateNumbers();
		}
		PlayerInfo.winning = 0;
		btn_Start.gameObject.SetActive(false);
		btn_Bet.gameObject.SetActive(false);
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
				result[j, i] = GetSymbol(); 
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
			lines[0].gameObject.SetActive(true);
		}
		if(result[1, 0] == result[1, 1] && result[1, 1] == result[1, 2] && result[1, 0] != 0)
		{
			CalcWin(result[1,0]);
			oneWin = true;
			jackpot_counter++;
			lines[1].gameObject.SetActive(true);
		}
		if (result[2, 0] == result[2, 1] && result[2, 1] == result[2, 2] && result[2, 0] != 0)
		{
			CalcWin(result[2, 0]);
			oneWin = true;
			jackpot_counter++;
			lines[2].gameObject.SetActive(true);
		}
		if (result[0, 0] == result[1, 1] && result[1, 1] == result[2, 2] && result[0, 0] != 0)
		{
			CalcWin(result[0, 0]);
			oneWin = true;
			jackpot_counter++;
			lines[3].gameObject.SetActive(true);
		}
		if (result[2, 0] == result[1, 1] && result[1, 1] == result[0, 2] && result[2, 0] != 0)
		{
			CalcWin(result[2, 0]);
			oneWin = true;
			jackpot_counter++;
			lines[4].gameObject.SetActive(true);
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
		btn_Bet.gameObject.SetActive(true);

	}

	private int GetSymbol()
	{
		int erg = Random.Range(1, 101);

		if (erg <= 5) return 5;			//5%
		if (erg <= 20) return 4;			//15%
		if (erg <= 35) return 3;			//15%
		if (erg <= 50) return 2;			//15%
		if (erg <= 75) return 1;			//25%
		if (erg <= 100) return 0;       //25%
		return 0;

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
		PlayerInfo.winning = 0;
		switch (item)
		{
			case 0:
				break;
			case 1:
				PlayerInfo.winning += PlayerInfo.bet * 2;
				break;
			case 2:
				PlayerInfo.winning += PlayerInfo.bet * 5;
				break;
			case 3:
				PlayerInfo.winning += PlayerInfo.bet * 10;
				break;
			case 4:
				PlayerInfo.winning += PlayerInfo.bet * 15;
				break;
			case 5:
				PlayerInfo.winning += PlayerInfo.bet * 20;
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
