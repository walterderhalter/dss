using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class PlayerInfo
	{
	public static int Money { get; set; }
	public static int Bet { get; set; } = 10;
	public static int Winning { get; set; } = 0;

	public static int[,] columns = new int[3, 3];

	public static bool checkWin = false;

	public static bool jackpot = false;


	public static void Save()
	{
		PlayerPrefs.SetInt("Money", Money);
		PlayerPrefs.Save();
	}
	
}

