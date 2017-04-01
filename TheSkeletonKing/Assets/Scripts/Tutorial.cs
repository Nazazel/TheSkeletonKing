using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public int objectiveNum;
	public bool introDone;
	public GameObject tutorialBox;
	public Text tutorialText;

	// Use this for initialization
	void Start () {
		objectiveNum = 0;
		introDone = false;
		tutorialText = GameObject.Find ("Text").GetComponent<Text>();
		tutorialBox.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (!introDone){
			StartCoroutine ("intro");
			introDone = true;
		}
		else if (objectiveNum == 0 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj1Complete)
		{
			StartCoroutine ("door1complete");
			objectiveNum++;
		}
		else if (objectiveNum == 1 && GameObject.FindWithTag("TutorialKey").GetComponent<TutorialKey>().obj2Complete)
		{
			StartCoroutine ("key1");
			objectiveNum++;
		}
		else if (objectiveNum == 2 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj3Complete)
		{
			StartCoroutine ("door2complete");
			objectiveNum++;
		}
		else if (objectiveNum == 3 && GameObject.FindWithTag("TutorialSoulStation").GetComponent<TutorialSoulStation>().obj4Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 4 && GameObject.FindWithTag("TutorialKey2").GetComponent<TutorialKey>().obj5Complete)
		{
			StartCoroutine ("key2");
			objectiveNum++;
		}
		else if (objectiveNum == 5 && GameObject.FindWithTag("TutorialSoulStation").GetComponent<TutorialSoulStation>().obj6Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 6 && GameObject.FindWithTag("TutorialKey3").GetComponent<TutorialKey>().obj7Complete)
		{
			StartCoroutine ("key3");
			objectiveNum++;
		}
		else if (objectiveNum == 7 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj8Complete)
		{
			objectiveNum++;
		}
			
	}

	public void setTutorialText(string hint)
	{
		tutorialText.text = hint;
	}

	public IEnumerator intro()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		setTutorialText ("Good day, player! Welcome to the tutorial! Here, you will learn the basic mechanics of our game.\nYou could either press the SpaceBar or the Enter key on your keyboard to progress through dialogue.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setTutorialText ("You are currently playing as the Red Knight's soul. Try going to the door at the end of this hall.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

	public IEnumerator door1complete()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		setTutorialText ("Hm, the door didn't open. That must mean you need a key to open it! Since you're currently playing as the Red Knight's soul, why don't you grab the key that's behind the black pits with the red aura?");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setTutorialText ("Use the \"E\" key on your keyboard to obtain the key.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

	public IEnumerator key1()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		setTutorialText ("Perfect! Now try that door again.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

	public IEnumerator door2complete()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		setTutorialText ("Hm, I guess you need all three keys to open the doors in this game. Since you have one of them, you only need to get the other two to complete this tutorial!");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setTutorialText ("But be warned, player! You must use the Soul Stations to switch between the fallen knights' souls in order to pass through the Skeleton King's intricate traps.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setTutorialText ("Now, try passing through the blue spikes as the Red Knight's soul (just kidding, don't do that. No seriously, you'll die).");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		setTutorialText ("Okay, but for realz this time, go back to the Soul Station towards the beginning of the hallway and press the \"E\" key on your keyboard to switch to the Blue Knight's soul. Then pass through the blue spikes and use the \"E\" key on your keyboard to pick up the key.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

	public IEnumerator key2()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		setTutorialText ("I think you're getting the hang of this, player! Now, go back to the Soul Station and change into the Green Knight's soul (remember, press \"E\"). Then, go collect the key behind the green arrow plates (by pressing \"E\").");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}

	public IEnumerator key3()
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = false;
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		tutorialBox.SetActive (true);
		setTutorialText ("Congratulations! You've gotten all three keys! Now, simply head to the door and it will open for you.");
		yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.Return));
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("Player").GetComponent<PlayerController> ().canMove = true;
		tutorialBox.SetActive (false);
	}
}
