using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

	// Use this for initialization
	public void newGameButton (string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
	}
	
	// Update is called once per frame
	public void ExitGameButton()
    {
        Application.Quit();
    }
		
}

