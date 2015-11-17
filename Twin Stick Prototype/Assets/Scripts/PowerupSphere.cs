using UnityEngine;
using System.Collections;

public class PowerupSphere : MonoBehaviour
{
    Transform revolveAround; //object for powerup sphere to revolve around
    float rotationSpeed = 360f; //how many degrees to rotate a second

    void Start()
    {
        revolveAround = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(revolveAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
