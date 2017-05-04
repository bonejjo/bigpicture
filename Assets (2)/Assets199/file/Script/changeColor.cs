using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {
    public GameObject p;
    public byte alpha = 0;
    public int count=0;

	// Use this for initialization
	void Start () {
        p = GameObject.FindGameObjectWithTag("ccc");
		/*GameObject thePlayer = GameObject.Find("ThePlayer");
		playMovie PlayMovie = thePlayer.GetComponent<playMovie>();
		PlayMovie.mPos -= 10.0f;
		GameObject.Find("TheMovie").GetComponent<playMovie>().mPos;*/
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
			
			/*for (int i = PlayMovie.mPos.x - 10; i < PlayMovie.mPos.x + 10; i++) {
				for (int j = PlayMovie.mPos.y - 10; j < PlayMovie.mPos.y + 10; j++) {
					p.GetComponent<SpriteRenderer> ().material.color = new Color32 (0, 255, 0, alpha);
				}
			}*/
			//p.GetComponent<SpriteRenderer> ().material.color = new Color32 (0, 255, 0, alpha);
            p.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, alpha);
            count++;
            if (count > 0)
            {
                alpha++;
                p.GetComponent<MeshRenderer>().material.color = new Color32(0, 255, 0, alpha);
            }
        }
	}
}
