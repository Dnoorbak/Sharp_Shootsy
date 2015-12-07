using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;
    public float inaccuracy = 0f;
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
            Vector3 direction = transform.up + Random.insideUnitSphere * inaccuracy;
            //direction.z = 90;
            //transform.rotation = Quaternion.LookRotation(transform.forward, direction);

            GameObject.Instantiate(bullet, transform.position, Quaternion.LookRotation(transform.forward, direction));
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