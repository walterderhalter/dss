using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Leiter : MonoBehaviour
{



	private int position;
	private bool start=true;
	private bool schalter;
	private int c;
	private int p1;
	private int p2;
	private List<int> price;
	private protected int[] multipliaktoren = new int[] { 0, 2, 5, 7, 10, 20, 40, 70, 100, 200 };

	// Start is called before the first frame update
	void Start()
	{
		
		SetPrice();
		SetButtons();
		GetPostion();
		

		schalter = true;
		
	}


	private void SetPrice()
	{
		price = new List<int>() { 0,0,0,0,0,0,0,0,0,0};

		for (int i = 0; i < 10; i++)
		{
			price[i] = multipliaktoren[i] * PlayerInfo.Bet;
		}

	}
	private void SetButtons()
	{
		for (int i = 0; i < 10; i++)
		{
			GameObject.Find("txt" + (i+1)).GetComponent<Text>().text = price[i].ToString();
		}
	}

	private void GetPostion()
	{
		Debug.Log(price.Contains(PlayerInfo.Winning));
		if (price.Contains(PlayerInfo.Winning))
		{
			position= price.IndexOf(PlayerInfo.Winning);
			p1 = position + 1;
			p2 = position - 1;
			Debug.Log(position);
			GameObject.Find("box" + position).GetComponent<Image>().color = Color.green;
		}

		for (int i = 0; i < 10; i++)
		{
			if (PlayerInfo.Winning > price[i] && PlayerInfo.Winning < price[i+1])
			{
				p1 = i;
				p2 = i + 1;
			}
		}
	}




	public  void Stop_Normal()
	{
		start = false;
		int rnd_int = Random.Range(0, 10);
		GameObject.Find("box" + (p1)).GetComponent<Image>().color = Color.white;
		GameObject.Find("box" + (p2)).GetComponent<Image>().color = Color.white;
		try
		{
			GameObject.Find("box" + position).GetComponent<Image>().color = Color.white;
		}
		catch { }
	
		
		
		if (rnd_int <= 3)
		{
			position=p1;
			p1=position+1;
			p2 = position - 1;
		}
		else if (rnd_int >= 4)
		{
			position=p2;
			p1 = position + 1;
			p2 = position - 1;
		}

			GameObject.Find("box" + position).GetComponent<Image>().color = Color.green;
		
	}


	public void End_Click()
	{
		StartCoroutine(End());
	}

	public IEnumerator End()
	{
		enabled = false;
		
		if (!start) PlayerInfo.Winning = price[position];
		PlayerInfo.Money += PlayerInfo.Winning;
		Debug.Log(PlayerInfo.Money);
		PlayerInfo.Save();
		Debug.Log("Leiter beendet:  " + PlayerInfo.Winning);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("SampleScene");


	}



	

	// Update is called once per frame
	void Update()
	{
		if (p2 < 0)
			StartCoroutine(End());
			
		if(p1 > 9)
		{
			//Musik Hier
			StartCoroutine(End());
		}

		else
		{
			
			

				if (schalter)
				{
					GameObject.Find("box" + p1).GetComponent<Image>().color = Color.red;
					GameObject.Find("box" + p2).GetComponent<Image>().color = Color.white;
					c++;
				}
				else
				{
					GameObject.Find("box" + p1).GetComponent<Image>().color = Color.white;
					GameObject.Find("box" + p2).GetComponent<Image>().color = Color.red;
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
