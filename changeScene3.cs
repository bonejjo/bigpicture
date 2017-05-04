using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Threading;

//아두이노
public class changeScene3 : MonoBehaviour
{
    SerialPort st = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    // Use this for initialization
    void Start()
    {
        st.Open();
    }
    private void OnApplicationQuit()
    {
        st.Close();
    }

    // Update is called once per frame
    void Update()
    {
        string da = null;
        Debug.Log("A");
        try
        {
            if (st.IsOpen)
            {
                da = st.ReadLine();
                st.ReadTimeout = 30;
            }

        }
        catch (System.Exception) { }

        Debug.Log(da);

        if (da == "3")
        {
            Application.LoadLevel("step3");
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
