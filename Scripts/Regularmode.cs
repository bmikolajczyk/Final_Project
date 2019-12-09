using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Regularmode : MonoBehaviour
{


	void Update()
	{
		if (Input.GetKey(KeyCode.G))
		{
			SceneManager.LoadScene("SampleScene"); // or whatever the name of your scene is
		}
	}

}

