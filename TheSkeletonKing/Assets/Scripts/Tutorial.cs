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
		if (objectiveNum == 0 && GameObject.FindWithTag("TutorialDoor").GetComponent<TutorialDoor>().obj1Complete) {
			objectiveNum++;
		}







	}
		
}
