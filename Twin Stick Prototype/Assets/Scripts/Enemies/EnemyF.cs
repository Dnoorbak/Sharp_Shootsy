using UnityEngine;
using System.Collections;

public class EnemyF : BaseEnemy {
	public float speed = 0.1f;
	public int FractalLeft = 4;
	public float FractalRate = 4;
	public float throwyDecreaseRate = 0.88f;
	public float throwyMag = 0.01f;
	public bool ______________;
	public Vector3 throwy;

	// Use this for initialization
	void Start () {
		throwy = new Vector3 (Random.Range (-throwyMag, throwyMag), Random.Range (-throwyMag, throwyMag));
		speed *= Random.Range (0.88f, 1.12f);
	}

	
	// Update is called once per frame
	public	override void FixedUpdate() {
		if (player != null)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position,
			                                              this.player.transform.position, speed);

			this.transform.position  += throwy;
			throwy*=throwyDecreaseRate;
		}
	}
	public override void  Death()
	{
//		print ("hhelo inside");
//		print (FractalLeft);
		if (this.FractalLeft >= 1) {
			for (int i = 0; i < FractalRate; i++) {
				
			
			GameObject temp = (GameObject)Instantiate (this.transform.parent.GetComponent<enemyHelper> ().prefabs [5], this.transform.position, transform.rotation);
			//print (i+" Created a "+temp.name);
			//temp.GetComponent<BaseEnemy> ().UpLevel (Level);
			temp.GetComponent<EnemyF> ().FractalLeft = this.FractalLeft - 1;
			temp.transform.parent = this.gameObject.transform.parent.transform;
			}
		}

		base.Death ();
	}
}
