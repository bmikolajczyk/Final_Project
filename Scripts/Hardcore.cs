using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hardcore : MonoBehaviour
{
	

    void Update()
	{
		if (Input.GetKey(KeyCode.H))
		{
			SceneManager.LoadScene("Hardmode"); // or whatever the name of your scene is
		}
	}

}
