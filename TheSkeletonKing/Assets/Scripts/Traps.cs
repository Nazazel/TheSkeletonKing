using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    //get soul color from other class
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
        if (soulColor == "red" && (trap.tag == "spikes" || trap.tag == "arrows"))
            {
            //DELETE PLAYER CODE
            //so that everything resets
            SceneManager.LoadScene("Lose");
            }

        else if (soulColor == "blue" && (trap.tag == "pitfalls" || trap.tag == "arrows"))
        {
            //DELETE PLAYER CODE
            //so that everything resets
            SceneManager.LoadScene("Lose");
        }

        else if (soulColor == "green" && (trap.tag == "pitfalls" || trap.tag == "spikes"))
        {
            //DELETE PLAYER CODE
            //so that everything resets
            SceneManager.LoadScene("Lose");
        }
    }

}
