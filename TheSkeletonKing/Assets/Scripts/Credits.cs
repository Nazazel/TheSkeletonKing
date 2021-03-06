﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public bool started = false;
    public Text theText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            StartCoroutine("waitThreeSeconds");
        }
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(3.0f);
        theText.text = "Project Leads:\n\nNazely  Hartoonian\n\nUlises Perez";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 30;
        theText.text = "Programmers:\n\nUlises Perez\n\nYixuan (Angela) Li\n\nZican  Li\n\nShiyang Fang\n\nShuzhan Xie";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 90;
        theText.text = "Artist:\n\nClaudia O'Flaherty";
        yield return new WaitForSeconds(3.0f);
        theText.text = "Audio:\n\nNazely  Hartoonian";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 40;
        theText.text = "Design:\n\nUlises Perez\n\nYixuan (Angela) Li\n\n Nazely  Hartoonian";
        yield return new WaitForSeconds(3.0f);
        theText.text = "All audio downloaded from Freesound.org";
        yield return new WaitForSeconds(3.0f);
        theText.text = " ";
		StartCoroutine (AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(),2.5f));
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Menu");





    }
}
