using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattle : MonoBehaviour {
	public int bossHealth;
	public Image bar;
	public bool started;

	public bool laugh;
	// Use this for initialization
	void Start () {
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
}
