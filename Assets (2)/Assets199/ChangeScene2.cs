using UnityEngine;

using System.Collections;
public class ChangeScene2 : MonoBehaviour
{
    private static ChangeScene2 s_Instance = null;
    // Use this for initialization 

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame 

    void Update()
    {

    }

    public static ChangeScene2 instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = new GameObject("ChangeScene2").AddComponent<ChangeScene2>();
                //오브젝트가 생성이 안되있을경우 생성. 
            }
            return s_Instance;
        }
    }


    void OnApplicationQuit()
    {
        s_Instance = null;
        //게임종료시 삭제. 
    }
} 
