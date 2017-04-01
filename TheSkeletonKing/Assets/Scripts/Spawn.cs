using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		GameObject.Find ("Player").transform.position = gameObject.transform.position;
	}

}
