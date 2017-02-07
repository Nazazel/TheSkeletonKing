using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public int objectiveNum;

	// Use this for initialization
	void Start () {
		objectiveNum = 0;
	}

	// Update is called once per frame
	void Update () {
		if (objectiveNum == 0 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj1Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 1 && GameObject.FindWithTag("TutorialKey").GetComponent<TutorialKey>().obj2Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 2 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj3Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 3 && GameObject.FindWithTag("TutorialSoulStation").GetComponent<TutorialSoulStation>().obj4Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 4 && GameObject.FindWithTag("TutorialKey2").GetComponent<TutorialKey>().obj5Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 5 && GameObject.FindWithTag("TutorialSoulStation").GetComponent<TutorialSoulStation>().obj6Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 6 && GameObject.FindWithTag("TutorialKey3").GetComponent<TutorialKey>().obj7Complete)
		{
			objectiveNum++;
		}
		else if (objectiveNum == 7 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj8Complete)
		{
			objectiveNum++;
		}




	}

}
