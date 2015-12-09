using UnityEngine;
using System.Collections;

public class WeaponPowerup : MonoBehaviour {
    public string type;
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
            Instantiate(effect, transform.position, transform.rotation);
            GameObject.DestroyObject(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
