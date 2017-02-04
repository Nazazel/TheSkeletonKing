using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startingTime = 10;
    public float timeLeft;
    public Slider timeSlider;
    public bool started;
    public bool leverPulled;
    public int numberOfLeversPulled;

    // Use this for initialization
    void Start()
    {
        timeSlider.value = startingTime;
        timeLeft = startingTime;
        //change to false later
        started = true;
        leverPulled = false;
        numberOfLeversPulled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (!leverPulled)
            {
                timeSlider.value -= Time.deltaTime;
                timeLeft -= Time.deltaTime;

                //if run out of time
                if (timeLeft <= 0)
                {
                    //GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerAnimator.Play("");
                    DestroyImmediate(GameObject.FindWithTag("Player"));
                    Debug.Log("Player killed");
                    SceneManager.LoadScene("Lose");
                }

                //if there is time and player pulls lever (but not the last lever)
                if ((timeLeft > 0) && leverPulled && numberOfLeversPulled < 3)
                {
                    //restart time, new lever not pulled, up count of number of levers pulled
                    timeLeft = startingTime;
                    timeSlider.value = startingTime;
                    leverPulled = false;
                    numberOfLeversPulled++;
                    Debug.Log("lever pulled++");
                }

                if (numberOfLeversPulled == 3)
                {
                    timeSlider.value = 0;
                    DestroyImmediate(timeSlider);
                }
            }
        }
    }
}
