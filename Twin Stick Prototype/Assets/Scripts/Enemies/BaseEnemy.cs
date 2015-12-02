using UnityEngine;
using System.Collections;

public abstract class BaseEnemy : MonoBehaviour {
	public GameObject player;
    public GameObject explosion;
    protected int value = 100;
	public int level = 1;
    // Use this for initialization
    void Awake()
	{
		this.player = GameObject.FindGameObjectWithTag ("Player");

	}
	void Start () {
	
	}

	public void UpLevel(int l)
	{
		this.level += 1;

	}

    // Update is called once per frame
    public abstract void FixedUpdate ();

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player Shot")
        {
            this.Death();
        }
    }

    void Death()
    {
        if (player != null)
        {
            var playerScript = player.GetComponent<PlayerControl>();
            playerScript.score += value;

            if (playerScript.powerupGauge < playerScript.PowerupThreshold)
                playerScript.powerupGauge += value;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        GameObject.DestroyObject(this.gameObject);
    }
}
