using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    public float speed;
    public float accelFactor;
    public float lifetime;
    public int dmg;
    //public float inaccuracy = 0f;
    // Use this for initialization
    void Start()
    {
        //GameObject.DestroyObject(this.gameObject, lifetime);
        //Vector3 direction = transform.up + Random.insideUnitSphere * inaccuracy;
        //Vector3 direction = transform.rotation.eulerAngles;
        //direction.z = 90;
        //transform.rotation = Quaternion.LookRotation(transform.forward, direction);
        Invoke("Death", lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += accelFactor;
        GetComponent<Rigidbody>().velocity = speed * Time.fixedDeltaTime * transform.up;
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Player Shot" && collision.gameObject.tag != "Powerup")
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