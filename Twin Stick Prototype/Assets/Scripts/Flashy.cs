using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flashy : MonoBehaviour {
    public float a = 3;
    public float b = 1;
    public float c = 4;
    public float d = 2;
    public float e = 2;
    public float f = 2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().color =
          new Color(1f - Mathf.Sin(Time.time / a) / d,
          0.5f +Mathf.Cos(Time.time/b)/e,
          0.5f + Mathf.Sin(Time.time / c) / f);
    
       // this.GetComponent<Text>().
       //  this.GetComponent<Text>().color =
       //new Color(this.GetComponent<Text>().color.r,
       //0.5f + Mathf.Cos(Time.time / 1) / 2f,
       //this.GetComponent<Text>().color.b);
       //  print(0.5f + Mathf.Cos(Time.time / 1) / 2f);


    }
}
