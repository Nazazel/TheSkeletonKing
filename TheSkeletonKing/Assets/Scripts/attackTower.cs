using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTower : MonoBehaviour {
	public bool requireButtonPress;
	private bool waitForPress;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitForPress && Input.GetKey (KeyCode.E)) 
		{
			GameObject.FindWithTag("Boss").GetComponent<BossBattle>().damageBoss();
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.GetComponent <BoxCollider2D> ().enabled = false;
			waitForPress = false;
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
