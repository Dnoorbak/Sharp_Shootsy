using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {
	public GameObject player;
    public GameObject explosion;
    // Use this for initialization
    void Awake()
	{
		this.player = GameObject.FindGameObjectWithTag ("Player");

	}
	void Start () {
	
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
        Instantiate(explosion, transform.position, transform.rotation);
        GameObject.DestroyObject(this.gameObject);
    }
}
