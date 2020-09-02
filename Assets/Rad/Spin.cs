using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spin : MonoBehaviour
{
	public Canvas Wheel;
	public int Speed;
	public Text txt_Winning;
	private float _rotationSpeed;
	private float _rotationDecrease = 50.0f;
	private List<bool> Slots = new List<bool>() { true, true, true, true, true };
	private int winMoney;


	// Start is called before the first frame update
	void Start()
	{
		Debug.Log(Wheel.transform.eulerAngles.z);
		enabled = false;
		_rotationSpeed = Random.Range(200.0f, 380.0f);
		winMoney = PlayerInfo.Winning;
		//txt_Winning.text = winMoney.ToString();
	}

	public void StartClick()
	{
		enabled = !enabled;
		_rotationSpeed = Random.Range(200.0f, 380.0f);
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
		int slotNr = (int)(Wheel.transform.eulerAngles.z / 72);

		if (Slots[slotNr])
		{
			
			Slots[slotNr] = false;
			PlayerInfo.Winning += winMoney;
			txt_Winning.text = PlayerInfo.Winning.ToString();

			if (Slots.Count(x => x == false) == 5) {
				Debug.Log("Alle getroffen");
				StartCoroutine(End(2));

			}
		}
		else
		{
			Debug.Log("Loser");
			StartCoroutine(End(2));

		}
	}

	public IEnumerator End(int time)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("SampleScene");
	}
}
