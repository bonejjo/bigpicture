using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMovie: MonoBehaviour {
    public GameObject mt;
    public float distanceFromCamera = 0.01f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        MovieTexture movie = this.GetComponent<Renderer>().material.mainTexture as MovieTexture;
        mt = GameObject.FindGameObjectWithTag("movie");

        if (Input.GetMouseButton(0))
        {
			//mt.GetComponent<Rigidbody> ().IsKinematic = true;
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
            Debug.Log(pos);
            pos = Camera.main.ScreenToWorldPoint(pos);
            Debug.Log(pos);
			mt.GetComponent<Transform> ().position = pos;

            if (!movie.isPlaying)
                movie.Play();
            else
                movie.Stop();
			
			/*if (this.GetComponent<Renderer>().material.mainTexture.isPlaying) {
				this.GetComponent<Renderer>().material.mainTexture.Pause ();
			} else {
				this.GetComponent<Renderer>().material.mainTexture.Play ();
			}*/
		}
	}
}
