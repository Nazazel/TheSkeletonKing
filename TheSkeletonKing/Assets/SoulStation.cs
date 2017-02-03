using UnityEngine;
using System.Collections;

public class SoulStation : MonoBehaviour {

	public bool requireButtonPress;
	private bool waitForPress;

	// Use this for initialization
	void Start () {
		waitForPress = false;
		requireButtonPress = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(waitForPress && Input.GetKeyDown(KeyCode.E))
		{
			if (GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul < 3) {
				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul++;
			} 
			else {
				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul = 1;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player") {
			if (requireButtonPress) {
				waitForPress = true;
				return;
			}

		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.name == "Player")
		{
			waitForPress = false;
		}
	}

}
