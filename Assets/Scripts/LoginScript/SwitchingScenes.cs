using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.LoginScript;

public class SwitchingScenes : MonoBehaviour, ISwitchingScenes
{
    //public variables
    public AsyncOperation sceneLoading;
    public string sceneName;
    public bool newScene;
    private Vector3 cameraPosition;

    //private variables
    private MainInfo mainInfo;
    private ConfigureServer configureServer;
    private DefaultGameInformation defaultGameInformation;

    //camera position
    private float x,y,z;

    /// <summary>
    /// Causes that attached GameObject Login
    /// is still available when scene is changed
    /// </summary>

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();

    }

    /// <summary>
    /// Get and set for the camera scoordinates
    /// </summary>

    public float X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }
    public float Y
    {
        get
        {
            return Y;
        }
        set
        {
            y = value;
        }
    }
    public float Z
    {
        get
        {
            return z;
        }
        set
        {
            z = value;
        }
    }
    /// <summary>
    /// Called every frame, checks which position the camera is at
    /// </summary>

    void Update()
    {
        if (newScene)
        {
            cameraPosition = GameObject.Find("CardboardMain").transform.position;
        }
    }

    /// <summary>
    /// Checking which position is saved in the database
    /// </summary>

    public void CheckPosition()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.Username);
        form.AddField("Job","CheckPosition");

        configureServer.ServerConnection(form);

        StartCoroutine(PositionStatus(configureServer.WWW));
    }

    /// <summary>
    /// Loads given scene
    /// </summary>

    public void LoadingScenes(string levelName)
    {
        sceneLoading = SceneManager.LoadSceneAsync(levelName);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadSceneWait());
    }

    /// <summary>
    /// Waits before activating scene, when done loading active scene
    /// When scene is being actived calls method ChamgePosition.
    /// </summary>

    IEnumerator LoadSceneWait()
    {
        while (sceneLoading.progress < 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log("progress:" + sceneLoading.progress);
        }

        sceneLoading.allowSceneActivation = true;
        Debug.Log("Done loading");
        ChangePosition();
    }

    /// <summary>
    /// Change position from the camera with the received new position from the database
    /// </summary>

    public void ChangeCameraPosition()
    {
        cameraPosition = new Vector3(X, Y, Z);
        GameObject camera = GameObject.Find("CardboardMain");
        camera.transform.position = cameraPosition;
    }

    /// <summary>
    /// Checks if the active is the scene that was being loaded to proceed,
    /// when the coordinates are empty it will get default coordinates linked to the scene
    /// </summary>

    public void ChangePosition()
    {
        if (sceneLoading.allowSceneActivation == true && SceneManager.GetActiveScene().name == sceneName)
        {
            if (X != 0.0F)
            {
              ChangeCameraPosition();
            }
            else
            {
                defaultGameInformation = new DefaultGameInformation(); 
                defaultGameInformation.GetCoordinates(SceneManager.GetActiveScene().name);
                ChangeCameraPosition();
            }         
        }

        else
        {
            mainInfo.Login.Feedback = "Waiting for scene to be loaded";
        }
    }

    /// <summary>
    /// Check if the username has coordinates and scene saved from the last time played,
    /// if not use default setting.
    /// </summary>

    IEnumerator PositionStatus(WWW www)
    {
        yield return www;

        if (www.text == "empty")
        {
            Debug.Log("New account, empty positions var");
            sceneName = "Game";
            LoadingScenes(sceneName);
        }
        else
        {
            string[] position = www.text.Split(',');
      
            X = float.Parse(position[0]);
            Y = float.Parse(position[1]);
            Z = float.Parse(position[2]);
            sceneName = (position[3]);

            LoadingScenes(sceneName);                          
        }
    }

}//End Class SwitchingScenes