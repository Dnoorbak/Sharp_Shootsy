using UnityEngine;
using System.Collections;

public abstract class BaseEnemy : MonoBehaviour {
	public GameObject player;
    public GameObject explosion;
    public GameObject[] powerups;
    public float dropChance = 0.02f;
    public int value = 100;
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

    void UpdateScore ()
    {
        var playerScript = player.GetComponent<PlayerControl>();
        playerScript.score += value;
    }

    void UpdateHighScore ()
    {
        var playerScript = player.GetComponent<PlayerControl>();
        if (playerScript.score > HighScoreKeeper.highScore)
        {
            HighScoreKeeper.highScore = playerScript.score;
        }
    }

    void UpdatePowerupGauge ()
    {
        var playerScript = player.GetComponent<PlayerControl>();

        if (playerScript.powerupGauge < playerScript.PowerupThreshold && !playerScript.timePowerTriggered)
            playerScript.powerupGauge += value;
    }

    public virtual void Death()
    {
        if (player != null)
        {
            UpdateScore();
            UpdateHighScore();
            UpdatePowerupGauge();            
        }

        if (powerups != null)
        {
            float roll = Random.Range(0f, 1f);
            if (roll <= dropChance)
            {
                Instantiate(powerups[Random.Range(0, powerups.Length)], transform.position, transform.rotation);
            }


        }

        Instantiate(explosion, transform.position, transform.rotation);
        GameObject.DestroyObject(this.gameObject);
    }
}
