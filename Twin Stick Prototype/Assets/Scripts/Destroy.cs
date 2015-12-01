using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    public float delay = 0;
    public float scale = 1;
    public float mag = 1;
    // Use this for initialization
    void Awake () {
        GameObject.Destroy(this.gameObject, delay);
	}

    //void Update()
    //{
        //this.GetComponent<ParticleSystem>().playbackSpeed = this.GetComponent<ParticleSystem>().playbackSpeed * Mathf.Cos(Time.deltaTime*scale)*mag;
        //this.GetComponentInChildren<ParticleSystem>().playbackSpeed = 0.6f;
    //}
}
