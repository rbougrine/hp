using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserPosition : MonoBehaviour
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class handles the position of the user
    /// when switching from scene and logging into the game
    /// </summary>

    //public variable
    public string sceneName, username, x, y, z;
    public float X, Y, Z;

    //private variable
    private Vector3 cameraPosition;
    private ConfigureServer configureServer;
    private MainInfo mainInfo;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();
        mainInfo.SwitchingScenes.newScene = true;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>

    void Update()
    {
        cameraPosition = GameObject.Find("CardboardMain").transform.position;        
    }

    /// <summary>
    /// Collect all the recent new information about the position, active scene
    /// and the username which will be send to retrieveInfo()
    /// </summary>

    public void collectInfo()
    {             
        x = CameraPosition.x.ToString("0.00");
        y = CameraPosition.y.ToString("0.00");
        z = CameraPosition.z.ToString("0.00");
      
        sceneName = SceneManager.GetActiveScene().name;
        username = mainInfo.StatusBarModel.username;
        
        retrieveInfo();
    }

    /// <summary>
    /// Save the new position data to the database to be saved with the current scene name.
    /// </summary>

    void sendInfo()
    {      
        WWWForm form = new WWWForm();

        form.AddField("x", x);
        form.AddField("y", y);
        form.AddField("z", z);
        form.AddField("username", username);
        form.AddField("scene", sceneName);
        form.AddField("Job","SavePosition");

        WWW www = new WWW(configureServer.URL, form);

        StartCoroutine(saveInfo(configureServer.WWW));
    }

    /// <summary>
    /// Get the recent saved position data from the database
    /// </summary>

    void retrieveInfo()
    {      
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("sceneName",sceneName);
        form.AddField("Job","RetrievePosition");

        configureServer.ServerConnection(form);

        StartCoroutine(getInfo(configureServer.WWW));
    }

    /// <summary>
    /// Save new position to the database
    /// </summary>

    IEnumerator saveInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text + "saveInfo compleet");
        }

    }

    /// <summary>
    /// Receive data from the database and check if the data is empty 
    /// or its from the same scene or the data is from the scene you about the enter
    /// </summary>

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

                X = float.Parse(position[0]);
                Y = float.Parse(position[1]);
                Z = float.Parse(position[2]);

                sendInfo();
            }
         }
    }

    /// <summary>
    /// Getter and Setter for the Vector3 CameraPosition
    /// </summary>

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
}
