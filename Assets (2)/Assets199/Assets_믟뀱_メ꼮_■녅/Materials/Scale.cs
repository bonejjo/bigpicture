using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	public float maxScale = 0.5f;
	public float minScale = 2.0f;
	public float shrinkSpeed = 1.0f;    

	private float targetScale;
	private Vector3 v3Scale;

	void Start() {
		//v3Scale = transform.localScale;
        }

	void Update()
	{
        v3Scale = new Vector3(maxScale, maxScale, maxScale);
        transform.localScale = Vector3.Lerp(transform.localScale, v3Scale/2.5f, Time.deltaTime * shrinkSpeed);
        /*
        RaycastHit hit;
		Ray ray;

		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.transform == transform) {
				targetScale = minScale;
				v3Scale = new Vector3(targetScale, targetScale, targetScale);
			}

		}

		if (Input.GetMouseButtonDown (1)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.transform == transform) {
				targetScale = maxScale;
				v3Scale = new Vector3(targetScale, targetScale, targetScale);
			}
		}

		transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, Time.deltaTime*shrinkSpeed);
	    */
    }

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}
}