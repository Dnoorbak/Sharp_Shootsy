﻿using UnityEngine;
using System.Collections;

public class EnemyC : BaseEnemy {
	public float rotationSpeed = 36000f;
    public float chargeSpeed = 1.0f;
    public float chargeDistance = 2.4f;
    public enum State {FINDING, CHARGING, RECOVERING};
	public State state=State.FINDING;
	public Vector3 chargeEndingPosition;
    public float recoveryTime = 1;
	float timeToRecover = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public	override void FixedUpdate() {
        if (player != null)
        {
            //while(Quaternion.

            //this.transform.rotation = 
            if (state == State.FINDING)
            {
                Quaternion newRotation = Quaternion.LookRotation((this.player.transform.position - this.transform.position).normalized);

                //Need a world up?
                //			print (newRotation.ToString());

                //	transform.rotation = Quaternion.Slerp (this.transform.rotation, newRotation, rotationSpeed*Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(this.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);


                if (Mathf.Abs(Quaternion.Angle(transform.rotation, newRotation)) < 10)
                {
                    Ray chargeRay = new Ray(this.transform.position, (player.transform.position - this.transform.position).normalized);
                    this.chargeEndingPosition = chargeRay.GetPoint(Vector3.Distance(player.transform.position, this.transform.position) * chargeDistance);
                    state = State.CHARGING;

                }
            }
            else if (state == State.CHARGING)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, chargeEndingPosition, chargeSpeed);
                if (Vector3.Distance(this.transform.position, chargeEndingPosition) < 1)
                {
                    timeToRecover = recoveryTime;
                    state = State.RECOVERING;
                }

            }
            else if (state == State.RECOVERING)
            {
                timeToRecover -= Time.deltaTime;
                if (timeToRecover < 0)
                    this.state = State.FINDING;
            }

        }
	}
}
