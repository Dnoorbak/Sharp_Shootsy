﻿using UnityEngine;
using System.Collections;

public class enemyHelper : MonoBehaviour {
    public int rate = 1;
    public int level = 0;
	public GameObject[] prefabs; 
	// Use this for initialization


	void Start () {
        InvokeRepeating("Spawn", 5, 1);
	}
	
	// Update is called once per frame
	void Update () {
	    //if ((int)Random.Range (0, 100) == 1) {
	    //		GameObject tempObject =	GameObject.Instantiate(prefabs[(int)Random.Range(0,4)]);
	    //		tempObject.GetComponent<BaseEnemy>().gameObject.transform.position  = new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0);
		//}
	
	}

    void Spawn()
    {
        for (int i = 0; i < rate; i++)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0), transform.rotation);
            //tempObject.GetComponent<BaseEnemy>().gameObject.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        }
        level++;

        if (level % 30 == 0)
        {
            rate++;
            print("rate: " + rate);
        }
    }
}
