using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWin : MonoBehaviour
{

	public Sprite[] sprites;

	// Start is called before the first frame update
	void Start()
    {
		
    }

	public void check1()
	{
		Invoke("Check", 5);
	}


	public void Check()
	{
		int[] result = { 0, 0, 0 };

		for (int i = 0; i < 3; i++)
		{
			result[i] = Random.Range(0, 2);
			Debug.Log("Yeet"+i.ToString());
			GameObject.Find("Image" + i.ToString()).GetComponent<Image>().sprite = sprites[result[i]];

		}




	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
