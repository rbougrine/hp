using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserPosition : MonoBehaviour
{
    //public variable
    public string sceneName, username;
    public string x, y, z;
    public float X, Y, Z;

    //private variable
    private Vector3 cameraPosition;
    private GameObject statusBar;
    private StatusBarModel statusBarModel;
    private GameObject loginScript;
    private Login login;

    //This script will continue to be used even when the scenes are switched
    void Awake()
    {
        DontDestroyOnLoad(this); 
    }

    void Start()
    {
        statusBar = GameObject.Find("StatusBar");
        statusBarModel = statusBar.GetComponent<StatusBarModel>();

        loginScript = GameObject.Find("Login");
        login = loginScript.GetComponent<Login>();

    }

    void Update()
    {
       if (LoginScript.camera2 != null && LoginScript.camera2.activeSelf)
       {
           cameraPosition = GameObject.Find("CardboardMain").transform.position;
       }
    }

    public Login LoginScript
    {
        get
        {
            return login;
        }

    }
    public StatusBarModel StatusBarModel
    {
        get
        {
            return statusBarModel;
        }
    }

    public Vector3 CameraPosition
    {
        get
        {
            return cameraPosition;
        }
        set
        {
            cameraPosition = value; 
        }
    }
  
    // Collect all the recent new information about the position, active scene
    //and the username which will be send to retrieveInfo()
    public void collectInfo()
    {
      
        x = CameraPosition.x.ToString("0.00");
        y = CameraPosition.y.ToString("0.00");
        z = CameraPosition.z.ToString("0.00");
      
        sceneName = SceneManager.GetActiveScene().name;
        username = StatusBarModel.username;
        
        retrieveInfo();
    }

    //Save the new position data to the database to be saved with the current scene name.
    void sendInfo()
    {
        string url = "http://145.24.222.160/savePosition.php";
 
        WWWForm form = new WWWForm();
        form.AddField("x", x);
        form.AddField("y", y);
        form.AddField("z", z);
        form.AddField("username", username);
        form.AddField("scene", sceneName);
        WWW www = new WWW(url, form);

        StartCoroutine(saveInfo(www));

    }

    //Get the recent saved position data from the database
    void retrieveInfo()
    {
        string url = "http://145.24.222.160/retrievePosition.php";

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("sceneName",sceneName);
        WWW www = new WWW(url, form);
      
        StartCoroutine(getInfo(www));

    }

    //Save new position to the database
    IEnumerator saveInfo(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text + "saveInfo compleet");
        }

    }

    //Receive data from the database and check if the data is empty 
    //or its from the same scene or the data is from the scene you about the enter
    IEnumerator getInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.text == "change")
            {
                sendInfo();
            }
            else
            {
                string[] position = www.text.Split(',');

                //assign the numbers to new position camera variables
                X = float.Parse(position[0]);
                Y = float.Parse(position[1]);
                Z = float.Parse(position[2]);

                sendInfo();
            }
           
         }
    }
    
}
