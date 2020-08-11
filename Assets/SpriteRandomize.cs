using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRandomize : MonoBehaviour
{
	public Sprite[] sprites;	//Iconliste
	public float StopTime;	//Stopt die Methode (in sek) Achtung!!!: Muss immer mit der Invoke Zeit in CheckWin übereinstimmen
	private int counter;		//Counter für iUpdate


	void Start()
    {
		counter = UnityEngine.Random.Range(0, sprites.Length);
		RandomImage();
		StopTime = 2;
		enabled = false;
	}

	//Eigene Update Funktion mit einstellbarer Framerate
	void iUpdate()
	{
		RandomImage();
		counter++;
	}

	//Wählt ein zufälliges Bild aus der Liste aus
	 void RandomImage()
	{
		if (counter >= sprites.Length)
		{
			counter = 0;
		}
		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[counter];	
	}

	//Startet das Drehen 
	public void StartRand()
	{
		InvokeRepeating("iUpdate", 0, 0.1f);
		enabled = true;
		Invoke("EndRand", StopTime);
	}

	//Beendet da drehen (wird von StartRand nach StopTime aufgerufen)
	void EndRand()
	{
		enabled = false;
		CancelInvoke();
		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;
	}


	




	// Update is called once per frame
	void Update()
	{


	}
}
