using UnityEngine;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;


public class mysqlS2 : MonoBehaviour
{
    // connection object192.168.25.9
    private string sqlDBip = "localhost";
    private string sqlDBname = "bigpicture";
    private string sqlDBid = "root";
    private string sqlDBpw = "yb1234";
    public bool pooling = true;

    private string connectionString;
    private MySqlConnection con = null;
    int index = 109;

    public GameObject picture;
    GameObject gameObj;
    Texture2D[] textList;
    string[] files;
    string pathPreFix;
    string rowStr;
    string img;
    mysqlTest mysqlScript;
    GameObject theMysql;

    string Awake()
    {

        theMysql = GameObject.Find("TheMysql");
        mysqlScript = theMysql.GetComponent<mysqlTest>();
        index = mysqlTest.index;
          
        connectionString = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + ";Port=" + "3307" + ";Pooling=";
        if (pooling)
        {
            connectionString += "true;";
        }
        else
        {
            connectionString += "false;";
        }
        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("Mysql State: " + con.State);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        DataSet ds = new DataSet();
        string sql = "select * from picture where id='" + index + "'";

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = new MySqlCommand(sql, con);
        adapter.Fill(ds);

        if (ds.Tables.Count > 0)
        {
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                /*foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    Debug.Log(dc.ColumnName);
                }*/
                Debug.Log(r["id"]);
                Debug.Log(r["pic_name"]);
                rowStr = r["pic_name"].ToString();
            }
        }
        return rowStr;
    }

    void OnApplicationQuit()
    {
        if (con != null)
        {
            if (con.State.ToString() != "Closed")
            {
                con.Close();
                Debug.Log("Mysql connection closed");
            }
            con.Dispose();
        }
    }

    void Start()
    {
        picture = GameObject.FindGameObjectWithTag("pic");
        string path = @"C:\Bitnami2\wampstack-5.6.30-2\apache2\htdocs\img\";

        pathPreFix = @"file://";

        files = System.IO.Directory.GetFiles(path, ".jpg");

        gameObj = GameObject.FindGameObjectWithTag("pic");
        img = path + rowStr;

        //textList = new Texture2D[files.Length];
        int dummy = 0;

        Debug.Log(img);
        string pathTemp = pathPreFix + img;
        Debug.Log(pathTemp);
        WWW www = new WWW(pathTemp);
        //yield return www;

        int texWidth = www.texture.width;
        int texHeight = www.texture.height;

        Texture2D texTmp = new Texture2D(texWidth, texHeight, TextureFormat.DXT1, false);
        www.LoadImageIntoTexture(texTmp);
        //TextureFormat.DXT1
        //textList[dummy] = texTmp;
        //Debug.Log(texTmp);
        gameObj.GetComponent<Renderer>().material.SetTexture("_MainTex", texTmp);
    }
}


