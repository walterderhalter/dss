using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CheckWin : MonoBehaviour
{

	public AudioSource winSound;
	public AudioSource loseSound;
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
		if (PlayerPrefs.HasKey("Money"))
		{
			PlayerInfo.Money = PlayerPrefs.GetInt("Money");
		}
		else
		{
			PlayerInfo.Money = 500;
			PlayerPrefs.SetInt("Money", 500);
		}
		PlayerPrefs.Save();
		UpdateNumbers();
		txtWin.text = PlayerInfo.Winning.ToString();

	}





	public void StartClick()
	{
		PlayerInfo.Save();
		if (oneWin)
		{
			PlayerInfo.Money += PlayerInfo.Winning - PlayerInfo.Bet;
			txtWin.text = PlayerInfo.Winning.ToString();
			UpdateNumbers();
			oneWin = false;
			for (int i = 0; i < lines.Length; i++) lines[i].gameObject.SetActive(false);
		}
		else
		{
			PlayerInfo.Money -= PlayerInfo.Bet;
			UpdateNumbers();
		}
		PlayerInfo.Winning = 0;
		btn_Start.gameObject.SetActive(false);
		btn_Bet.gameObject.SetActive(false);
		
	}

	//Wechselt auf die Leiter
	public void Switch()
	{
		btn_Leiter.gameObject.SetActive(false);
		SceneManager.LoadScene("Leiter");
	}

	
	

	//Checkt nach Gewinn
	public void Check()
	{
		int[,] result = PlayerInfo.columns;
		int jackpot_counter = 0;
		#region Zu Viel IFs
		#region Bitte lass es zu, des is echt peinlich 
		PlayerInfo.Winning = 0;
		if (result[0, 0] == result[0, 1] && result[0, 1] == result[0, 2] && result[0, 0] != 0)
		{
			CalcWin(result[0, 0]);
			oneWin = true;
			jackpot_counter++;
			lines[0].gameObject.SetActive(true);
		}
		if (result[1, 0] == result[1, 1] && result[1, 1] == result[1, 2] && result[1, 0] != 0)
		{
			CalcWin(result[1, 0]);
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
			Debug.Log("EIN GEWINN!!!!!!" + PlayerInfo.Winning);
			winSound.Play();
			btn_Leiter.gameObject.SetActive(true);
			txtWin.text = PlayerInfo.Winning.ToString();
		}
		else
		{
			loseSound.Play();
		}

		UpdateNumbers();
		btn_Start.gameObject.SetActive(true);
		btn_Bet.gameObject.SetActive(true);

	}

	//Gibt ein zufälliges Symbol zurück
	private int GetSymbol()
	{
		int erg = Random.Range(1, 101);

		if (erg <= 5) return 5;             //5%
		if (erg <= 20) return 4;            //15%
		if (erg <= 35) return 3;            //15%
		if (erg <= 50) return 2;            //15%
		if (erg <= 75) return 1;            //25%
		if (erg <= 100) return 0;           //25%
		return 0;

	}

	//Wechselt den Einsatz
	public void SwitchBet()
	{
		betIndex++;
		if (betIndex >= bets.Length) betIndex = 0;
		PlayerInfo.Bet = bets[betIndex];
		txtBet.text = PlayerInfo.Bet.ToString();
		Debug.Log(txtBet.text);
	}

	//Erechnet anhand des Einsatzs und des
	private void CalcWin(int item)
	{
		switch (item)
		{
			case 0:
				break;
			case 1:
				PlayerInfo.Winning += PlayerInfo.Bet * 2;
				break;
			case 2:
				PlayerInfo.Winning += PlayerInfo.Bet * 5;
				break;
			case 3:
				PlayerInfo.Winning += PlayerInfo.Bet * 10;
				break;
			case 4:
				PlayerInfo.Winning += PlayerInfo.Bet * 15;
				break;
			case 5:
				PlayerInfo.Winning += PlayerInfo.Bet * 20;
				break;

			default:
				break;
		}
	}

	//Aktualisiert die angezeigen Zahlen
	private void UpdateNumbers()
	{
		txtMoney.text = PlayerInfo.Money.ToString();
		txtBet.text = PlayerInfo.Bet.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		if (PlayerInfo.checkWin)
		{
			Check();
			PlayerInfo.checkWin = false;
		}
	}
}
