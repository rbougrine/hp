using UnityEngine;
using System.Collections;

public class UIMan : MonoBehaviour {
    public string InfoStatusbar;
    public GUIStyle labelStyle;
    public GUIStyle scorestyle;
    // Use this for initialization
    private StatusBar statusBar;
    public int score;
    public GameObject statusbar;
     

    void Start () {

        statusBar = statusbar.GetComponent<StatusBar>();

    }


    void Awake()
    {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update () {
	
	}

    public StatusBar StatusBar {
        get {

            return statusBar;


        }



    }

  public void Bar()
    {

        InfoStatusbar = statusBar.InfoStatusbar;
        GUI.Box(new Rect(250, 150, 260, 20), InfoStatusbar, labelStyle);
     

        GameObject points = GameObject.Find("Score");
        PointCounter pointcounter = points.GetComponent<PointCounter>();
        score = pointcounter.score;
        GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);
       






    }
}
