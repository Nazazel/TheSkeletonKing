using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour {
	public int bossHealth;
	public 
	// Use this for initialization
	void Start () {
		bossHealth = 3;

	}
	
	// Update is called once per frame

	public void damageBoss () {
		if (bossHealth > 0)
			bossHealth--;
	}


	void Update()
	{
		if (bossHealth == 0) 
		{
			GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().endGame = true;
			//gameObject.GetComponent (Animator).Play ("");
			GameObject.FindWithTag ("Player").GetComponent <PlayerController>().StartCoroutine("gameEnd");
		}
	}
}
