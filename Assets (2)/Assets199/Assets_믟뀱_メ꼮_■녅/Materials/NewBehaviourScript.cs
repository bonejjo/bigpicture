using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public GameObject prefab;
	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {



		ray=Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray,out hit))
		{

			if(Input.GetMouseButtonDown(0))
			{

				Vector3 mousePos = Input.mousePosition;
				mousePos.z = 10.0f;
				mousePos = Camera.main.ScreenToWorldPoint(mousePos);
				mousePos.y = 0.4f;

				
				GameObject obj=Instantiate(Resources.Load("Quad"),mousePos, Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
				//new Vector3(hit.point.x,hit.point.y,hit.point.z)
			}

		}



	}
}