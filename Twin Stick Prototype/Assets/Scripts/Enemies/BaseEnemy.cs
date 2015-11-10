using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Awake()
	{
		this.player = GameObject.Find ("Player_1");

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		//Simplest movement, intended to be overidden
		this.transform.position = Vector3.MoveTowards (this.transform.position,
		                                               this.player.transform.position, 0.1f*Time.deltaTime);
	}



}
