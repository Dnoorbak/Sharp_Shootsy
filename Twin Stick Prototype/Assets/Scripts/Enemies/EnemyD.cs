using UnityEngine;
using System.Collections;

public class EnemyD : BaseEnemy {
	public float speed = 0.04f;
	public bool _____________________;
	public float stateOffset1;
	public float stateOffset2;
	public float stateOffset3;
	// Use this for initialization
	void Start() {
		stateOffset1 = Random.Range (-4f, 4f);

		stateOffset2 = Random.Range (-4f, 4f);
		stateOffset3 = Random.Range (-4f, 4f);
	}
	
	// Update is called once per frame
	public override void FixedUpdate() {
		if (player != null)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position,
			                                              this.player.transform.position, speed);
			float sinFactor = 5f;
			float sigMagnatude = 0.2f;
			this.transform.position += new Vector3(
				Mathf.Clamp(Mathf.Tan((stateOffset1 + Time.time) * sinFactor),-4,4) * sigMagnatude,
				Mathf.Clamp(Mathf.Tan((stateOffset3 + Time.time) * sinFactor),-4, 4) * sigMagnatude,
				0);
			float sinFactor2 = -2f;
			float sigMagnatude2 = 0.5f;
			this.transform.position += new Vector3(Mathf.Sin((stateOffset2 + Time.time) * sinFactor) * sigMagnatude, Mathf.Cos((stateOffset2 +Time.time) * sinFactor) * sigMagnatude, 0);
			
			
			
		}
	}
}
