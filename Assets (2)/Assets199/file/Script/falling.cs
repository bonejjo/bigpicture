using UnityEngine;
using System.Collections;
 
public class fallSphere : MonoBehaviour {
 
     public float fallSpeed = 8.0f;
     public float spinSpeed = 250.0f;
 
     void Update() {
         if (Input.GetMouseButton(0))
         {
             transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
             //transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
         }
         
 
     }
 
     /*void OnMouseDown() {
 
         renderer.enabled = false;
 
     }*/
 
}
