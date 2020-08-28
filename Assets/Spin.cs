using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spin : MonoBehaviour
{
	public Canvas Wheel;
	public int Speed;

	private float _rotationSpeed;//= Random.Range(250.0f, 330.0f);
	private float _rotationDecrease = 50.0f;
	private List<bool> Slots = new List<bool>() { true, true, true, true, true };
	

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log(Wheel.transform.eulerAngles.z);
		enabled = false;
		_rotationSpeed= Random.Range(200.0f, 330.0f);

	}

	public void StartClick()
	{
		enabled = !enabled;
		_rotationSpeed = Random.Range(200.0f,330.0f);
	}

    // Update is called once per frame
    void Update()
    {
		if (_rotationSpeed >= 0)
		{
			_rotationSpeed -= _rotationDecrease * Time.deltaTime;

			Wheel.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
			
		}
		else
		{
			GetLocation();
			enabled = false;
		}
		

    }

	private void GetLocation()
	{
		Debug.Log(Wheel.transform.eulerAngles.z / 72);
		int slotNr =(int) (Wheel.transform.eulerAngles.z/72);
		Debug.Log(slotNr);

		if (Slots[slotNr])
		{
			//Gewinn & Weiter
		}
		else
		{
			//Verloren & Zurück
		}
	}
}
