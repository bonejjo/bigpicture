using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour {
    public static int cnt = 0;
    public static int cnt2 = 0;
    public static int currentCnt = 0;
    public static int index = 109;

    // Use this for initialization
    void Start () {
        currentCnt++;

        cnt2 = cnt;
        cnt = currentCnt;

        Debug.Log("currentCnt");
        Debug.Log(currentCnt);

        if (cnt2 != cnt && currentCnt % 3 == 0)
        {
            index++;
            Debug.Log("index");
            Debug.Log(index);
        }
    }
    /*void Reset()
    {
        if (cnt > 0)
        {
            cnt2 = cnt;
            cnt = currentCnt;
            Debug.Log("cnt2");
            Debug.Log(cnt2);
            Debug.Log("cnt");
            Debug.Log(cnt);
            Debug.Log("current");
            Debug.Log(currentCnt);
            if (cnt2 != cnt)
            {
                index++;
                Debug.Log("인덱스");
                Debug.Log(index);
            }
        }
    }*/
    /*void OnLevelWasLoaded()
    {
        cnt2 = cnt;
        cnt = currentCnt;
        Debug.Log("cnt2");
        Debug.Log(cnt2);
        Debug.Log("cnt");
        Debug.Log(cnt);
        Debug.Log("current");
        Debug.Log(currentCnt);
        if (cnt2 != cnt)
        {
            index++;
            Debug.Log("인덱스");
            Debug.Log(index);
        }

    }*/
    // Update is called once per frame
    void Update () {
		
	}
}
