using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class PlayerControl : MonoBehaviour
{
    public float turnSpeed = 0.05f;
    public float speed = 1f;
    private Vector3 direction = new Vector3(0, 0, 0);
    private Rigidbody rb;
    public Launcher[] shots;
	public Text livesText;
    public Text scoreText;
    public float invCountdown = 0f;
	public int lives = 3;
    public int score = 0;
    public GameObject explosion;
    public GameObject damage;
    private bool alive;

    //Controller variables
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    float angle = 0.0f; //current angle ship is facing
    float previousAngle = 0.0f; //previous angle ship was facing
    public float leftVibration = 0.0f;
    public float rightVibration = 0.0f;

    void Start()
    {
		rb = GetComponent<Rigidbody> ();
		FollowCam.S.poi = this.gameObject;
		livesText.text = lives + "";
        //scoreText.text = score + "";
        alive = true;
        //speed = (1 / FollowCam.S.timeMag) *100;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (alive) {
            if (collision.gameObject.tag == "Enemy" && invCountdown <= 0)
            {
                HitVibration(true);

                FollowCam.S.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = true;
                //FollowCam.S.GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>().enabled = true;
                lives--;
                livesText.text = lives + "";
                invCountdown = 2;
                Instantiate(damage, transform.position, transform.rotation);
                if (lives <= 0)
                    Death();
            }
        }
	}

	void Update()
	{
		//livesText.text = lives + "";
        scoreText.text = score + "";
        if (invCountdown > 0)
        {
            invCountdown -= Time.deltaTime;
        }
        else
        {
            FollowCam.S.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = false;

            //turn vibration of controller off
            HitVibration(false);

            //FollowCam.S.GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>().enabled = false;
        }

        CheckControllerConnections();
    }

    void FixedUpdate()
    {
        if (state.IsConnected) { //xbox controller is connected
            if (alive)
            {
                PlayerMove();
                PlayerRotate();
                Fire();
            }
        }
        else { //non-xbox controls (ie, no vibration of controller)
            if (alive)
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
        }
    }

    void Death()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        alive = false;
        HitVibration(false);
        //GetComponent<BoxCollider>().enabled = false;
        GameObject.DestroyObject(this.gameObject);
    }

    void CheckControllerConnections()
    {
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);
    }

    void PlayerMove()
    {
        float moveHorizontal = state.ThumbSticks.Left.X;
        float moveVertical = state.ThumbSticks.Left.Y;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        rb.AddForce(movement * speed);
    }

    void PlayerRotate()
    {
        // Set a deadzone for the right stick
        if ((state.ThumbSticks.Right.X > -0.2 && state.ThumbSticks.Right.X < 0.2) &&
            (state.ThumbSticks.Right.Y > -0.2 && state.ThumbSticks.Right.Y < 0.2))
        {
            //if the stick wasn't moved enough, the current angle is whatever the angle was previously
            angle = previousAngle; 
        }
        else
        {
            //set our previous angle and then update our current angle
            previousAngle = angle;
            angle = Mathf.Atan2(state.ThumbSticks.Right.Y, state.ThumbSticks.Right.X) * Mathf.Rad2Deg;
        }

        //update the rotation of the player
        transform.rotation = Quaternion.AngleAxis(90.0f - angle, Vector3.back);
    }

    void HitVibration(bool shouldVibrate)
    {
        if (shouldVibrate)
        {
            // Set vibration
            leftVibration = rightVibration = 100.0f;
            GamePad.SetVibration(playerIndex, leftVibration, rightVibration);
        }
        else
        {
            //turn vibration of controller off
            leftVibration = rightVibration = 0.0f;
            GamePad.SetVibration(playerIndex, leftVibration, rightVibration);
        }
    }

    void Fire()
    {
        direction = new Vector3(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y, 0);

        foreach (Launcher s in shots)
        {
            s.Shoot();
        }
    }
}
