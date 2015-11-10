using UnityEngine;
using System.Collections;

public class EnemyA : BaseEnemy {
    public float speed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
 	public	override void FixedUpdate() {
        if (player != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                      this.player.transform.position, speed);
        }
	}
}
