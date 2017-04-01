using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DestroyImmediate(GameObject.FindWithTag("Player"));
		GameObject.Find ("leveltransition").GetComponent<LevelTransition> ().InvokeRepeating ("FadeToClear", 0.0f, 0.1f);
	}

}
