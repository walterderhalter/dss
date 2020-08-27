using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Roll : MonoBehaviour
{

	public Sprite[] Icons;
	public Image[] Fields;
	public int Column;
	


    // Start is called before the first frame update
    void Start()
    {
		Debug.Log(transform.position.y);
		enabled = false;
		SetStart(0,0,0);
    }

	private void SetStart(int i1,int i2,int i3)
	{
		Fields[3].sprite = Icons[i1];
		Fields[4].sprite = Icons[i2];
		Fields[5].sprite = Icons[i3];
	}

	public void ButtonClick()
	{


		transform.position = new Vector3(transform.position.x, 4.296f, transform.position.z);
		SetImages();

		switch (Column)
		{
			case 0:
				On();
				break;
			case 1:
				Invoke("On", 0.5f);
				break;
			case 2:
				Invoke("On", 1.0f);
				break;
			default:
				break;
		}


	}


	public void On() => enabled = true;


	public void SetImages()
	{
		for (int i = 0; i < 3; i++)
		{
			var item = Fields[i];
			int rndInt = Random.Range(0, 6);
			item.sprite = Icons[rndInt];
			PlayerInfo.columns[i,Column ] = rndInt;
		}
	}


	private float posiY = -1.0f;
    // Update is called once per frame
    void Update()
    {
		
		if (transform.position.y >= posiY)
		{
			transform.position += -transform.up * 4.0f * Time.deltaTime;
		}
		else
		{
			SetStart(PlayerInfo.columns[0, Column], PlayerInfo.columns[1, Column], PlayerInfo.columns[2, Column]);
			Vector3 newPosition = new Vector3(transform.position.x, posiY, transform.position.z);
			transform.position = newPosition;
			enabled = false;
			if (Column == 2) PlayerInfo.checkWin = true;//Hier weiterleitung
		}
	}

}
