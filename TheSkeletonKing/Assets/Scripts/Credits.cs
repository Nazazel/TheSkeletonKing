﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        theText = "Project Leads:\n\nNazely Hartoonian\n\nUlises Perez";
        yield return new WaitForSeconds(3.0f);
        theText = " ";
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Tutorial");





    }
}
