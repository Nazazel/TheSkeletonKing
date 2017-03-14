using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	public bool Ready;
	// Use this for initialization
	void Start () {
		Ready = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Ready && GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys == 3)
		{
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.FindWithTag("DoorCollider").GetComponent<PolygonCollider2D> ().enabled = false;
			GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().numKeys = 0;
			Ready = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Player")
			Ready = true;
		}
}
