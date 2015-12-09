using UnityEngine;
using System.Collections;

public class WeaponPowerup : MonoBehaviour {
    public int lifetime;
    public GameObject effect;
    // Use this for initialization
    void Awake () {
        GameObject.DestroyObject(this.gameObject, lifetime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.DestroyObject(this.gameObject);
            Instantiate(effect, transform.position, transform.rotation);

        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
