using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    public float delay = 0;
	// Use this for initialization
	void Awake () {
        GameObject.Destroy(this.gameObject, delay);
	}
}
