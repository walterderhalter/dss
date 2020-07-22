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
        
    }



    // Update is called once per frame
    void Update()
    {
		RandomImage();
		
    }

	 void RandomImage()
	{
		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];	
	}

	void EndRand()
	{
		enabled = false;
		gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;
	}

	public void StopRand()
	{
		Invoke("EndRand",StopTime);
	}

	public void StartRand()
	{
		enabled = true;
	}
}
