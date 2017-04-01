using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//Standard Unity Object Variables
	public Rigidbody2D rb;

	//1=RED, 2=BLUE, 3=GREEN
	public int currentSoul;
	public int numKeys;
	public bool endGame;
	public bool scenetransition;
	public string previousscene;
	public string currentscene;
	public bool canMove;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (GameObject.Find("Player"));
		previousscene = "";
		currentscene = SceneManager.GetActiveScene ().name;
		scenetransition = false;
		endGame = false;
		numKeys = 0;
		currentSoul = 1;
		rb = gameObject.GetComponent<Rigidbody2D> ();
		canMove = true;
	}

	// Update is called once per frame
	void Update () {
		currentscene = SceneManager.GetActiveScene ().name;

		if (previousscene != currentscene) {
			GameObject.Find ("leveltransition").GetComponent<LevelTransition> ().InvokeRepeating ("FadeToClear", 0.0f, 0.1f);
			scenetransition = true;
			previousscene = SceneManager.GetActiveScene ().name;
			StartCoroutine ("levelStart");
		}

		//Only left arrow key is read as input; if any directional key is pressed, then movement stops
		if (!scenetransition && !endGame && canMove) {
			
			if (Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
				if ((rb.velocity.x > 0.0f) && (rb.velocity.y != 0.0f)) {
					rb.velocity = new Vector2 (0.0f, 0.0f);
				}
				if (rb.velocity.x > -3.0f) {
					rb.velocity = new Vector2 (-2.0f, 0.0f);
				}
			} else if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
				if ((rb.velocity.x < 0.0f) && (rb.velocity.y != 0.0f)) {
					rb.velocity = new Vector2 (0.0f, 0.0f);
					
				}
				if (rb.velocity.x < 3.0f) {
					rb.velocity = new Vector2 (2.0f, 0.0f);
				}
			} else if (Input.GetKey (KeyCode.DownArrow) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
				if ((rb.velocity.y > 0.0f) && (rb.velocity.x != 0.0f)) {
					rb.velocity = new Vector2 (0.0f, 0.0f);
					
				}
				if (rb.velocity.y > -3.0f) {
					rb.velocity = new Vector2 (0.0f, -2.0f);
				}
			} else if (Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.DownArrow)) {
				if ((rb.velocity.y < 0.0f) && (rb.velocity.x != 0.0f)) {
					rb.velocity = new Vector2 (0.0f, 0.0f);
				}
				if (rb.velocity.y < 3.0f) {
					rb.velocity = new Vector2 (0.0f, 2.0f);
				}
			} else {
				rb.velocity = new Vector2 (0.0f, 0.0f);
			}
		}
	}

	public IEnumerator levelStart()
	{
		if (currentSoul == 1) {
			gameObject.GetComponent<Animator> ().Play ("RedSpawn");
		} 
		else if (currentSoul == 2) {
			gameObject.GetComponent<Animator> ().Play ("BlueSpawn");
		} 
		else if (currentSoul == 3) {
			gameObject.GetComponent<Animator> ().Play ("GreenSpawn");
		}
		yield return new WaitForSeconds (0.4f);
		if (currentSoul == 1) {
			gameObject.GetComponent<Animator> ().Play ("Red Orb Idle");
		} 
		else if (currentSoul == 2) {
			gameObject.GetComponent<Animator> ().Play ("Blue Orb Idle");
		} 
		else if (currentSoul == 3) {
			gameObject.GetComponent<Animator> ().Play ("Green Orb Idle");
		}
		scenetransition = false;
	}

	public IEnumerator gameEnd()
	{
		yield return new WaitForSeconds(0.1f);
	}

}


