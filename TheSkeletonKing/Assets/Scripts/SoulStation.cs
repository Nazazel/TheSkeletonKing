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
				gameObject.GetComponent<AudioSource> ().Play ();
				StopCoroutine ("OrbTransition");
				StartCoroutine ("OrbTransition");
				GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul++;
			} 
			else {
				gameObject.GetComponent<AudioSource> ().Play ();
				StopCoroutine ("OrbTransition");
				StartCoroutine ("OrbTransition");
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

	public IEnumerator OrbTransition()
	{
		if(GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul == 1)
		{
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Red Orb to Blue");
			yield return new WaitForSeconds(0.5f);
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Blue Orb Idle");
			StopCoroutine ("OrbTransition");
		}
		else if(GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul == 2)
		{
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Blue Orb to Green");
			yield return new WaitForSeconds(0.5f);
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Green Orb Idle");
			StopCoroutine ("OrbTransition");
		}
		else if(GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().currentSoul == 3)
		{
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Green Orb to Red");
			yield return new WaitForSeconds(0.5f);
			GameObject.FindWithTag ("Player").GetComponent<Animator> ().Play ("Red Orb Idle");
			StopCoroutine ("OrbTransition");
		}

	}

}
