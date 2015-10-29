using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;
    public float cooldownTimer;
    //public float offset;
    private bool canShoot = true;
    //public float accuracy = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Shoot()
    {
        if (canShoot)
        {
            //Quaternion rotation = 
            GameObject.Instantiate(bullet, transform.position, transform.rotation);
            //audio.Play();
            canShoot = false;
            Invoke("shotCooldown", cooldownTimer);
        }
    }

    void shotCooldown()
    {
        canShoot = true;
    }
}