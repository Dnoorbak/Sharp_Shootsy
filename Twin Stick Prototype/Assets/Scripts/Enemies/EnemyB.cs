using UnityEngine;
using System.Collections;

public class EnemyB : BaseEnemy
{

	public enum State
	{
		Avoiding,
		Attacking}
	;

	public float AvoidRange = 20;
	public float spotAngle = 100;
	public float speed = 0.8f;
	public float DistanceToStopAvoiding  = 2f;
	public float AvoidySpotRange = 100;
	public float avoidyDestinationRequiredDistanceFromPlayer = 10f;
	public float avoidySpeedMuliplyer = 1000f;
	public float SuisideDistance = 3f;
	public float SuicideSpeedMultiplyer = 3f;
	//public float escapeRange = 20;//should be proportional to escape range
		public State currentState = State.Attacking;
	public bool ______________________________;
	public Vector3 avoidSpot= Vector3.zero;
	// Use this for initialization
	// Update is called once per frame
	public override void FixedUpdate() {
		//do nothing please
	}


	void Update ()
	{
		if (player) {
			if (currentState == State.Attacking) {


				#region check if need to avoid
				Vector3 forward = player.transform.TransformDirection (Vector3.forward);
				float distance = Vector3.Distance (player.transform.position, this.transform.position);            
				Vector3 targetDirection = this.transform.position - player.transform.position;
				targetDirection.y = 0;
				float angle = Vector3.Angle (targetDirection, forward);
		             
				if (distance< SuisideDistance) {
					this.transform.position = Vector3.MoveTowards (transform.position,
				                                              this.player.transform.position, speed * Time.deltaTime * SuicideSpeedMultiplyer);
					//print ("Suicide");
					return;

				}
				//forwarrd is always zero, so up?
				if (//distance < AvoidRange // && angle < spotAngle   
				   // &&
				    Vector3.Dot(player.transform.up, (this.transform.position - player.transform.position).normalized)  > 0.7 //1 means looking at, -1 means not 
				    ) {
				//	print ("avoid");
					avoid (); //or attack or whatever
					return;
				}

				#endregion
				//print ("moving");

				this.transform.position = Vector3.MoveTowards (transform.position,
			                                              this.player.transform.position, speed * Time.deltaTime);
			} else if (currentState == State.Avoiding) {
			
				this.transform.position = Vector3.MoveTowards (transform.position,
			                                              avoidSpot, speed * Time.deltaTime * avoidySpeedMuliplyer);
				if (Vector3.Distance (this.transform.position, avoidSpot) < DistanceToStopAvoiding) {
					//stop avoiding
					currentState = State.Attacking;
				//	print ("attacking");

				}

			}
		}
	}

	public void avoid ()
	{
		float OriginalRange =AvoidySpotRange; //store this to return it back at the end
		int tryCount = 0;
		currentState = State.Avoiding;
		Vector3 tempSpot = ( Random.insideUnitCircle * AvoidySpotRange);
		avoidSpot = tempSpot + this.transform.position;
		while (

			!( Rect.MinMaxRect(-50, -50, 50,50).Contains(avoidSpot)) //inside
			||

			(Vector3.Distance(avoidSpot, player.transform.position)<avoidyDestinationRequiredDistanceFromPlayer)
		
		)
		{
			tryCount += 1;

			if (tryCount > 5) {//Expand Posible
				AvoidySpotRange *= 1.1f;//expand to find a better option

			}
			 tempSpot = ( Random.insideUnitCircle * AvoidySpotRange);
				avoidSpot = tempSpot + this.transform.position;
			
		}
	
	//reset the range back to where it was before the function call
	AvoidySpotRange = OriginalRange;
	}

}
