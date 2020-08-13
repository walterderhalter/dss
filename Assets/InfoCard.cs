using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCard : MonoBehaviour
{

	public float speed = 2.5f;
	private bool schalter = false;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log(transform.position);
		enabled = false;
		
	}

	public void StartClick()
	{
		enabled = true;
	}

	// Update is called once per frame
	void Update()
	{

		if (schalter) {

			if (transform.position.y > 7.15f) {
				schalter = false;
				enabled = false;
				transform.position.Set(transform.position.x,7.2f,transform.position.z) ;
					}

			else
				transform.position += transform.up * speed * Time.deltaTime;
		}
		else
		{
			if (transform.position.y < 2.9) { schalter = true; enabled = false; }

			else
				transform.position += -transform.up * speed * Time.deltaTime;
		}
	}
}
