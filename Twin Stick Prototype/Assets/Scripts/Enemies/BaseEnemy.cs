using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {
	public GameObject player;
    public GameObject explosion;
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
	public virtual void FixedUpdate () {
        if (player != null)
        {
            //Simplest movement, intended to be overidden
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                           this.player.transform.position, 0.1f * Time.deltaTime);
        }
	}

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
            player.GetComponent<PlayerControl>().score += value;

        Instantiate(explosion, transform.position, transform.rotation);
        GameObject.DestroyObject(this.gameObject);
    }
}
