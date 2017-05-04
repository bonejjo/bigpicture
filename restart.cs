using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

    GameObject g;
    public int count;
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("pic");
    }
    void Update()
    {
        if (g.GetComponent<Transform>().position.y >0.598)
        {
            count++;
            if (count > 120)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("b2");
                for(int i = 0; i < objects.Length; i++)
                {
                    Destroy(objects[i]);
                }

                SceneManager.LoadScene("03_step1");

            }

        }
    }
}
