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


	public static void Save()
	{
		PlayerPrefs.SetInt("Money", Money);
		PlayerPrefs.Save();
	}
	
}

