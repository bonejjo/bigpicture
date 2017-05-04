using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            Application.LoadLevel("step2");
        }
        if (Input.GetKeyDown("e"))
        {
            Application.LoadLevel("step3");
        }
	}
}
