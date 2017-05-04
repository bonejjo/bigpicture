using UnityEngine;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;

public class Load : MonoBehaviour
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
    public GameObject pictureR;
    public GameObject pictureL;
    GameObject gameObj;
    GameObject gameObjR;
    GameObject gameObjL;
    string[] files;
    string pathPreFix;
    string rowStr;
    string rowStrR;
    string rowStrL;
    string img;
    string imgR;
    string imgL;
    mysqlTest mysqlScript;
    GameObject theMysql;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //mtheMysql = GameObject.Find("TheMysql");
            //mysqlScript = theMysql.GetComponent<mysqlTest>();
            index++;
            Debug.Log("랄라");
            //index = mysqlTest.index;
        }
    }
    void Awake()
    {
        //index++;
        /*if (Input.GetMouseButton(0))
        {
            theMysql = GameObject.Find("TheMysql");
            mysqlScript = theMysql.GetComponent<mysqlTest>();
            index++;
            Debug.Log("랄라");
            index = mysqlTest.index;
        }*/
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
        DataSet dsL = new DataSet();
        DataSet dsR = new DataSet();

        string sql = "select * from picture where id='" + index + "'";
        string sqlL = "select * from picture where id='" + (index-1) + "'";
        string sqlR = "select * from picture where id='" + (index+2) + "'";

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = new MySqlCommand(sql, con);
        adapter.Fill(ds);
        MySqlDataAdapter adapterL = new MySqlDataAdapter();
        adapterL.SelectCommand = new MySqlCommand(sqlL, con);
        adapterL.Fill(dsL);
        MySqlDataAdapter adapterR = new MySqlDataAdapter();
        adapterR.SelectCommand = new MySqlCommand(sqlR, con);
        adapterR.Fill(dsR);

        if ((ds.Tables.Count > 0)&& (dsL.Tables.Count>0) && (dsR.Tables.Count > 0))
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
            foreach (DataRow rR in dsR.Tables[0].Rows)
            {
                /*foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    Debug.Log(dc.ColumnName);
                }*/
                Debug.Log(rR["id"]);
                Debug.Log(rR["pic_name"]);
                rowStrR = rR["pic_name"].ToString();
            }
            foreach (DataRow rL in dsL.Tables[0].Rows)
            {
                /*foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    Debug.Log(dc.ColumnName);
                }*/
                Debug.Log(rL["id"]);
                Debug.Log(rL["pic_name"]);
                rowStrL = rL["pic_name"].ToString();
            }
        }
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
        pictureR = GameObject.FindGameObjectWithTag("picR");
        pictureL = GameObject.FindGameObjectWithTag("picL");
        string path = @"C:\Bitnami2\wampstack-5.6.30-2\apache2\htdocs\img\";

        pathPreFix = @"file://";

        files = System.IO.Directory.GetFiles(path, ".jpg");

        gameObj = GameObject.FindGameObjectWithTag("pic");
        gameObjR = GameObject.FindGameObjectWithTag("picR");
        gameObjL = GameObject.FindGameObjectWithTag("picL");
        img = path + rowStr;
        imgR = path + rowStrR;
        imgL = path + rowStrL;
        //textList = new Texture2D[files.Length];

        Debug.Log(img);
        string pathTemp = pathPreFix + img;
        string pathTempR = pathPreFix + imgR;
        string pathTempL = pathPreFix + imgL;
        Debug.Log(pathTemp);
        WWW www = new WWW(pathTemp);
        WWW wwwR = new WWW(pathTempR);
        WWW wwwL = new WWW(pathTempL);
        //yield return www;

        int texWidth = www.texture.width;
        int texHeight = www.texture.height;
        int texWidthR = wwwR.texture.width;
        int texHeightR = wwwR.texture.height;
        int texWidthL = wwwL.texture.width;
        int texHeightL = wwwL.texture.height;

        Texture2D texTmp = new Texture2D(texWidth, texHeight, TextureFormat.DXT1, false);
        www.LoadImageIntoTexture(texTmp);
        gameObj.GetComponent<Renderer>().material.SetTexture("_MainTex", texTmp);

        Texture2D texTmpR = new Texture2D(texWidthR, texHeightR, TextureFormat.DXT1, false);
        wwwR.LoadImageIntoTexture(texTmpR);
        gameObjR.GetComponent<Renderer>().material.SetTexture("_MainTex", texTmpR);

        Texture2D texTmpL= new Texture2D(texWidthL, texHeightL, TextureFormat.DXT1, false);
        wwwL.LoadImageIntoTexture(texTmpL);
        gameObjL.GetComponent<Renderer>().material.SetTexture("_MainTex", texTmpL);
    }
}


