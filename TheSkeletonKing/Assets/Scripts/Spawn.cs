using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public Transform[] spawnPoints;
    public int spawnPointIndex;

	// Use this for initialization
	void Start ()
    {
        Instantiate(player, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
