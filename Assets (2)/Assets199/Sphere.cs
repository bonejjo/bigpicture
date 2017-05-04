using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
    Ray ray;
    RaycastHit hit;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray,out hit))
		{
            if (Input.GetMouseButtonDown(0))
            {
            //RaycastHit hit;
           // if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            //{
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10.0f;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.y = 10f;

                Vector3 v = Input.mousePosition;
                v.y=10;
                //Vector3 v = new Vector3(Input.mousePosition.x, 20, Input.mousePosition.z);
                //v = Camera.main.ScreenToWorldPoint(v);
                Debug.Log(v);
                GameObject myRoadInstance = Instantiate(Resources.Load("sphere"), mousePos, Quaternion.identity) as GameObject;
                Debug.Log(myRoadInstance.GetComponent<Transform>().position);
                if (myRoadInstance.GetComponent<Transform>().position.y == 1.9)
                {
                    Debug.Log("aaaaa");
                    Destroy(myRoadInstance);
                }
               
                //Collision col = myRoadInstance.GetComponent<Collision>();
                //OnCollisionEnter(col);
            }
        }
	}

    
}


