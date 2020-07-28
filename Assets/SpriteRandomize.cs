using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRandomize : MonoBehaviour
{
	public Sprite[] sprites;
	public float StopTime;
	public int Erg;


    void Start()
    {
		counter = UnityEngine.Random.Range(0, sprites.Length);
		InvokeRepeating("iUpdate", 0, 0.1f);

		
	}

	private int counter;

	void iUpdate()
	{
		RandomImage();
		counter++;
	}

    // Update is called once per frame
    void Update()
    {
		
		
    }

	 void RandomImage()
	{
		if (counter >= sprites.Length)
		{
			counter = 0;
		}
		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[counter];	
	}

	void EndRand()
	{
		enabled = false;
		CancelInvoke();
		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;
	}

	public void StopRand()
	{
		Invoke("EndRand",StopTime);
	}

	public void StartRand()
	{
		InvokeRepeating("iUpdate", 0, 0.1f);
		enabled = true;
	}
}
