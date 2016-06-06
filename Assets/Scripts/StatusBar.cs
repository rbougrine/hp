using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBar : MonoBehaviour
{
    public string username;
    public string Feedback = null;
    public int score;
    public string InfoStatusbar;

    // Gui style options to style gameobject wich it belongs
    public GUIStyle labelStyle;
    public GUIStyle scorestyle;
    private GameObject loginScript;
    private Login login;


    void Start()
    {
        loginScript = GameObject.Find("Login");
        login = loginScript.GetComponent<Login>();
    }

 
    // Managing that the statusbar game object wont be destoyed so it can be used in the garage scene
   void Awake()
    {
        DontDestroyOnLoad(this);

    }         

    public Login Login
    {
        get
        {
            return login;

        }

    }
    public void getInfo()
    {
        /*
        - Retrieving username of the user when logged in 
         the retrieved username from login is set to username string
         in the statusbar.
        */
       
        username = Login.Username;

        /*
        - Php script wich collects the info the user inserts in loginscreen 
        - With the retrieved username from Login a query is been done to get the 
          the right user informatie to parse to the statusbar GUI
        */

        string url = "http://145.24.222.160/getInfo.php";
        WWWForm form = new WWWForm();
        form.AddField("Username", username);


        WWW www = new WWW(url, form);

        StartCoroutine(userInfo(www));



    }

    IEnumerator userInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {

            Feedback = www.error;

        }
        else
        {
            // Information the database sends back when succesfully logged in 
            Feedback = www.text;

          // Retrieving parts of the information string from the datasbase 
           
            string[] position = Feedback.Split(',');
            InfoStatusbar = (position[0]);
           
            // Retrieve only score int from the database string www.text
            score = int.Parse(position[1]);
           

        }
    }

  

    void OnGUI()
    {
        // set userinformation to statusbar after login completed
        GameObject loginScreen = GameObject.Find("Login");
        Login Login = loginScreen.GetComponent<Login>();
        
 
        var CurrentMenu = Login.CurrentMenu;
        if (CurrentMenu == null)
        {
            Bar();
        }


    }

    void Bar()
    {
        
        /*
       -Creating statusbar Gui with information retrieved from the userinfo() method
        -Adding scrore from pointer to the StatusBar
        */
        GUI.Box(new Rect(250, 150, 260, 20), InfoStatusbar, labelStyle);
        GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);

        // getting score variable from PointCounter
     //   GameObject points = GameObject.Find("Cubes");
     //   PointCounter pointcounter = points.GetComponent<PointCounter>();


        // set pointercounter score to statusbar score
       // score = pointcounter.score;







    }
}


