using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{
    static public FollowCam S; //follow cam singleton
    public float timeMag = 0.5f;
    public float factor = 3;
    public float push = 4;
    //feilds set in inspector
    public float easing = 0.05f;
    //public Vector2 minXY;
    public bool ____________;
    // feilds set dynamically
    public GameObject poi; //point of interest
    public float camZ; //desired z position of the camera

    // Use this for initialization
    void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        Vector3 destination;
        //return if there is no poi return to 0,0,0
        if (poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            //get the position of the poi
            destination = poi.transform.position;
        }

        //limit the X & Y to minimum values
        //destination.x = Mathf.Max(minXY.x, destination.x);
        //destination.y = Mathf.Max(minXY.y, destination.y);
        //interpolate from the current camera position to the destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //retain a destination.z of camZ
        destination.z = camZ;
        //set camera to the destination
        transform.position = destination;
        //set the orthographic state of the camera to keep the ground in view
       // this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }

    void Update()
    {

        //Time.timeScale =(  Mathf.Cos(Time.time* timeMag) *factor)+push;
        Time.timeScale = timeMag;
        print(Time.timeScale);
    }
}
