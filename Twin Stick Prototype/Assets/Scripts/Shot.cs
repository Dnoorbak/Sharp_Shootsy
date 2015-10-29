using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    public float speed;
    public float accelFactor;
    public float lifetime;
    public int dmg;
    // Use this for initialization
    void Start()
    {
        GameObject.DestroyObject(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += accelFactor;
        GetComponent<Rigidbody>().velocity = speed * Time.fixedDeltaTime * transform.up;
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "Player")
            this.Death();
    }


    void OnBecameInvisible()
    {
        GameObject.DestroyObject(this.gameObject);
    }

    //what happens when the shot hits something
    void Death() {
        GameObject.DestroyObject(this.gameObject);
    }
}