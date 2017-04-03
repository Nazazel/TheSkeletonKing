using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattle : MonoBehaviour {

	public GameObject attackLever;
	Random rnd = new Random ();
	public GameObject randomizedObject;

	public ArrayList spawnlist = new ArrayList ();
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;
	public GameObject spawn5;
	public GameObject spawn6;
	public GameObject spawn7;
	public GameObject spawn8;

	public int numRandomized;
	public int bossHealth;
	public Image bar;
	public bool started;

	public bool laugh;
	// Use this for initialization
	void Start () {
		numRandomized = 0;
		spawnlist.Add (spawn1);
		spawnlist.Add (spawn2);
		spawnlist.Add (spawn3);
		spawnlist.Add (spawn4);
		spawnlist.Add (spawn5);
		spawnlist.Add (spawn6);
		spawnlist.Add (spawn7);
		spawnlist.Add (spawn8);
		StartCoroutine ("randomize");

		bar.fillAmount = 1;
		bossHealth = 3;
		laugh = true;
	}
	
	// Update is called once per frame

	public void damageBoss () {
		if (bossHealth > 0) {
			StartCoroutine ("damagevisible");
			bossHealth--;
		}
	}


	void Update()
	{
		if (bossHealth < 3) {
			bar.fillAmount = bossHealth * 0.33f;
		}
		if (laugh)
		{
			gameObject.GetComponent<Animator> ().Play ("SkeletonKingLaugh");
			laugh = false;
			StartCoroutine ("laughBoss");
		}
		if (bossHealth == 0 && !started) 
		{
			started = true;
			StopAllCoroutines ();
			StartCoroutine ("bossDeath");

		}
	}

	public IEnumerator laughBoss()
	{
		yield return new WaitForSeconds (1.0f);
		gameObject.GetComponent<Animator> ().Play ("SkeletonKing");
		yield return new WaitForSeconds (10.0f);
		laugh = true;
	}

	public IEnumerator damagevisible()
	{
		gameObject.GetComponent<Animator> ().Play ("SkeletonKingDamage");
		gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.5f);
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		gameObject.GetComponent<Animator> ().Play ("SkeletonKing");
		laugh = true;
	}

	public IEnumerator bossDeath()
	{
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().canMove = false;
		gameObject.GetComponent<Animator>().Play ("SkeletonKingDeath");
		yield return new WaitForSeconds (3.0f);
		GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().endGame = true;
		GameObject.FindWithTag ("Player").GetComponent <PlayerController>().StartCoroutine("gameEnd");
	}

	public IEnumerator randomize ()
	{
		yield return new WaitForSeconds (0.1f);
		randomizedObject = (GameObject)spawnlist[Random.Range(0,spawnlist.Capacity)];
		spawnlist.Remove (randomizedObject);
		Instantiate (attackLever, randomizedObject.transform.position, randomizedObject.transform.rotation);
		numRandomized += 1;
		if (numRandomized < 3) {
			StartCoroutine ("randomize");
		}
	}
}
