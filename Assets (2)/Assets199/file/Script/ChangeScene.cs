using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;

//아두이노
public class ChangeScene : MonoBehaviour {
    SerialPort sp = new SerialPort("COM3", 9600,Parity.None,8,StopBits.One);
    // Use this for initialization
	void Start () {
        
        sp.Open();
	}
    private void OnApplicationQuit()
    {
        sp.Close();
    }

    // Update is called once per frame
    void Update () {
        string data = null;
        Debug.Log("Asdgs");
        try
        {
            if (sp.IsOpen)
            {
                data = sp.ReadLine();
                sp.ReadTimeout = 30;
            }
            
        }
        catch (System.Exception) { }

        Debug.Log(data);

        if (data == "0")
        {
            Application.LoadLevel("step2");
        }
        //Input.GetKeyDown(KeyCode.W)
	}

    public void SceneChange1()
    {
        SceneManager.LoadScene("RipplePlay");
    }

    public void SceneChange2()
    {
        SceneManager.LoadScene("dustPlay");
    }
    //sp.Close();
}
