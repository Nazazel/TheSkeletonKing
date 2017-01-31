using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    public string trapName;
    //change to strings later once player class is done
    public bool soulRed = true;
    public bool soulBlue = true;
    public bool soulGreen = true;

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
        if (soulRed && (trapName == "spikes" || trapName == "arrows"))
            {
            SceneManager.LoadScene("Lose");
            }
    }

}
