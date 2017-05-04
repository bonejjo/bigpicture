using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		Vector3 TouchPosition = new Vector3();

		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				TouchPosition = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 0);
			}
		}
		//Ray ray=Camera.main.ScreenPointToRay(TouchPosition);
		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if(Physics.Raycast(ray,out hit))
		{
			//if (Input.GetMouseButton (0)) {
				Debug.Log ("1");
			if(hit.collider.name.Equals("WaterProDaytime (2)") ||hit.collider.tag.Equals("quad") )
				{
					Debug.Log ("2");
					Vector3 hitPoint = hit.point;

					hitPoint.y = 1;


					transform.position = hitPoint;
			//	}
		  }
		}
	}
}