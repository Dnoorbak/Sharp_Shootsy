using UnityEngine;
using System.Collections;

public class EnemyA : BaseEnemy {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
 	public	override void  Update () {
		this.transform.position = Vector3.MoveTowards (this.transform.position,
		                                              this.player.transform.position, 0.1f);
	}
}
