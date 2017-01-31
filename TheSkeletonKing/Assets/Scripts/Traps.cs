using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    public string trapName;
    //change to strings later once player class is done
    public string soulColor;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D trap)
    {
        if (soulColor == "red" && (trapName == "spikes" || trapName == "arrows"))
            {
            SceneManager.LoadScene("Lose");
            //DELETE PLAYER CODE
            //so that everything resets
            }

        else if (soulColor == "blue" && (trapName == "pitfalls" || trapName == "arrows"))
        {
            SceneManager.LoadScene("Lose");
            //DELETE PLAYER CODE
            //so that everything resets
        }

        else if (soulColor == "green" && (trapName == "pitfalls" || trapName == "spikes"))
        {
            SceneManager.LoadScene("Lose");
            //DELETE PLAYER CODE
            //so that everything resets
        }
    }

}
