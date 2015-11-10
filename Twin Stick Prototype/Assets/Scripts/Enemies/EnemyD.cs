using UnityEngine;
using System.Collections;

public class EnemyD : BaseEnemy {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public	override void  Update() {
		this.transform.position = Vector3.MoveTowards (this.transform.position,
		                                               this.player.transform.position, 0.04f);
		float sinFactor = 5f;
		float sigMagnatude = 0.2f;
		this.transform.position += new Vector3 (Mathf.Sin (Time.time*sinFactor)*sigMagnatude, Mathf.Cos (Time.time*sinFactor)*sigMagnatude, 0);
	}
}
