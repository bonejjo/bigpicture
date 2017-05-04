using UnityEngine;
using System.Collections;

public class ChangePixelColor : MonoBehaviour
{
    public Camera cam;
    public GameObject mt;
    public float distanceFromCamera = 5.0f;
    
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        mt = GameObject.FindGameObjectWithTag("movie");

        /*if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            return;

        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        Debug.Log("XYY:::" + pixelUV);
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        Debug.Log("X:::" + pixelUV.x + " Y::" + pixelUV.y);
        */

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
            pos = Camera.main.ScreenToWorldPoint(pos);
            mt.GetComponent<Transform>().position = pos;
            Debug.Log("sdf" + mt.GetComponent<Transform>().position.x + " fd" + mt.GetComponent<Transform>().position.y);
        }
        
    }
}

