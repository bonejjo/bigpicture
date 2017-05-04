using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step2Play : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5;
    }

    void FixedUpdate()
    {

        transform.Translate(speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        /*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveVertical, 0.0f, moveHorizontal);

		rb.AddForce (movement * speed);
		*/
    }
}
