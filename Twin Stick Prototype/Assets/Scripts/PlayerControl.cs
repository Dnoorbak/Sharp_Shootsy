using UnityEngine;
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
    public Text scoreText;
    public float invCountdown = 0f;
	public int lives = 3;
    public int score = 0;
    public GameObject explosion;
    public GameObject damage;
    private bool alive;

    void Start()
    {
		rb = GetComponent<Rigidbody> ();
		FollowCam.S.poi = this.gameObject;
		livesText.text = lives + "";
        //scoreText.text = score + "";
        alive = true;

    }
    void OnTriggerEnter(Collider collision)
    {
        if (alive) {
            if (collision.gameObject.tag == "Enemy" && invCountdown <= 0)
            {
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
        if (invCountdown > 0) {
			invCountdown -= Time.deltaTime;
		}
	}

    void FixedUpdate()
    {
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

    void Death()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        alive = false;
        //GetComponent<BoxCollider>().enabled = false;
        GameObject.DestroyObject(this.gameObject);
    }
}
