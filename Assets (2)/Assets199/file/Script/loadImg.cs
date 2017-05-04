using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadImg : MonoBehaviour {
    public GameObject picture;
    //public Image myPic;
    
    //public Color imageColorToBeUsed = Color.green;
   // public float currentImageColorAlpha = 0.5f;
    
    GameObject[] gameObj;
    Texture2D[] textList;

    string[] files;
    string pathPreFix;

	// Use this for initialization
	void Start () {
        picture = GameObject.FindGameObjectWithTag("pic");

        string path = @"C:\Users\yb\Desktop\bigPicture\";

        pathPreFix = @"file://";

        files = System.IO.Directory.GetFiles(path, "*.jpg");

        gameObj = GameObject.FindGameObjectsWithTag("pic");

        StartCoroutine(LoadImages());
        
        //myPic = GetComponent<Image>();
        //currentImageColorAlpha = myPic.color.a;
	}

    void Update()
    {
        
    }

    private IEnumerator LoadImages()
    {
        //load all images in default folder as textures and apply dynamically to plane game objects.
        //6 pictures per page
        textList = new Texture2D[files.Length];

        int dummy = 0;
        foreach (string tstring in files)
        {
            Debug.Log(tstring);
            string pathTemp = pathPreFix + tstring;
            Debug.Log(pathTemp);
            WWW www = new WWW(pathTemp);
            Debug.Log(www);
            yield return www;

            int texWidth = www.texture.width;
            int texHeight = www.texture.height;

            Texture2D texTmp = new Texture2D(texWidth, texHeight, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(texTmp);
            //TextureFormat.DXT1
            textList[dummy] = texTmp;

            gameObj[dummy].GetComponent<Renderer>().material.SetTexture("_MainTex", texTmp);
            dummy++;
        }
    }
}







