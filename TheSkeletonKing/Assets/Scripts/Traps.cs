using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    //get soul color from other class
    public int soulColor;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        soulColor = GameObject.FindWithTag("Player").GetComponent<PlayerController>().currentSoul;
    }

    void playDeathAnimation()
    {
        StartCoroutine("waitThreeSeconds");
    }

    IEnumerator waitThreeSeconds()
    {
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().endGame = true;
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().rb.velocity = new Vector2 (0.0f, 0.0f);;
		if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().currentSoul == 1) {
			GameObject.FindWithTag("Player").GetComponent<Animator>().Play("RedDeath");
		} 
		else if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().currentSoul == 2) {
			GameObject.FindWithTag("Player").GetComponent<Animator>().Play("BlueDeath");		
		} 
		else if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().currentSoul == 3) {
			GameObject.FindWithTag("Player").GetComponent<Animator>().Play("GreenDeath");		
		}

        yield return new WaitForSeconds(3.0f);
        GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
        SceneManager.LoadScene("Lose");
        DestroyImmediate(GameObject.FindWithTag("Player"));
    }

    void OnTriggerEnter2D(Collider2D trap)
    {
		if (soulColor == 1 && (gameObject.tag == "spikes" || gameObject.tag == "arrows"))
        {
            playDeathAnimation();
        }

		else if (soulColor == 2 && (gameObject.tag == "pitfalls" || gameObject.tag == "arrows"))
        {
            playDeathAnimation();
        }

		else if (soulColor == 3 && (gameObject.tag == "pitfalls" || gameObject.tag == "spikes"))
        {
            playDeathAnimation();
        }
    }
}
