using UnityEngine;
using System.Collections;

public class MineShot : MonoBehaviour {
    public int fragCount = 5;
    public GameObject fragment;

    public float speed;
    public float accelFactor;
    public float lifetime;
    public int dmg;
    // Use this for initialization
    void Start()
    {
        //GameObject.DestroyObject(this.gameObject, lifetime);
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
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Player Shot")
            this.Death();

    }


    void OnBecameInvisible()
    {
        GameObject.DestroyObject(this.gameObject);
    }

    void Death()
    {
        for (int i = 0; i < fragCount; i++)
        {
            //Quaternion fragRotation = Quaternion.AngleAxis( i * (360 / fragCount), Vector3.up);
            Quaternion fragRotation = Quaternion.AngleAxis(0, Random.insideUnitSphere);
            Instantiate(fragment, this.transform.position, fragRotation);
        }
        GameObject.DestroyObject(this.gameObject);
    }
}
