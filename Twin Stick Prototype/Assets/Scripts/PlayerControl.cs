﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float turnSpeed = 0.05f;
    public float speed = 1f;
    private Vector3 direction = new Vector3(0, 0, 0);
    private Rigidbody rb;
    public Launcher[] shots;
	public Text livesText;
	public float invCountdown = 0f;
	public int lives = 0;
    public GameObject explosion;

    void Start()
    {
		rb = GetComponent<Rigidbody> ();
		FollowCam.S.poi = this.gameObject;
		livesText.text = lives+"";

	}
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Enemy" && invCountdown <=0){
			lives --;
			invCountdown = 2;
            GetComponent<AudioSource>().Play();
            if (lives < 0)
                Death();
		}
	}

	void Update()
	{
		livesText.text =  lives+"";
		if (invCountdown > 0) {
			invCountdown -= Time.deltaTime;
		}
	}

    void FixedUpdate()
    {


        Vector3 rotation;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        rb.AddForce(movement * speed);

        if ((Input.GetAxis("Horizontal2") > 0.2 || (Input.GetAxis("Vertical2") > 0.2) || (Input.GetAxis("Horizontal2") < -0.2) || (Input.GetAxis("Vertical2") < -0.2)))
        {
            direction = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);

            foreach (Launcher s in shots)
            {
                s.Shoot();
            }
        }
        //transform.up = direction;
        rotation = Vector3.Lerp(transform.up, direction, turnSpeed);
        transform.up = rotation;
    }

    void Death()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        GameObject.DestroyObject(this.gameObject);
    }
}
