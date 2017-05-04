using UnityEngine;
using System.Collections;

public class BlurControl : MonoBehaviour {
	
	float value;
    int count;
	// Use this for initialization
	void Start () {
        count = 0;
        value = 1.5f;
		transform.GetComponent<Renderer>().material.SetFloat("_blurSizeXY",value);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            count++;
            value = (value - Time.deltaTime) % 50.0f;
			if (value<0f) value = 0f;
			transform.GetComponent<Renderer>().material.SetFloat("_blurSizeXY",value);
        }
        /*if (Input.GetKeyDown("a"))
		{
			value = value + Time.deltaTime;
			if (value>20f) value = 20f;
			transform.GetComponent<Renderer>().material.SetFloat("_blurSizeXY",value);
		}
        else if (Input.GetKeyDown("b"))
		{
			value = (value - Time.deltaTime) % 20.0f;
			if (value<0f) value = 0f;
			transform.GetComponent<Renderer>().material.SetFloat("_blurSizeXY",value);
		}*/		
	}
	
	/*void OnGUI () {
		GUI.TextArea(new Rect(10f,10f,200f,50f), "Press the 'Up' and 'Down' arrows \nto interact with the blur plane\nCurrent value: "+value);
		}*/
}
