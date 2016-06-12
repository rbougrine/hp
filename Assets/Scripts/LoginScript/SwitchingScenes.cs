using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchingScenes : MonoBehaviour
{
    //private variables
    private readonly string ip = "145.24.222.160";
    private StatusBar statusBar;
    private UserPosition userPosition;
    private Login login;

    //public variables
    public AsyncOperation sceneLoading;
    private GameObject statusBarScript, userPositionScript, loginScript;
  
    //camera position
    float X;
    float Y;
    float Z;

    public string sceneName;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
   
    // Use this for initialization
    void Start()
    {
        statusBarScript = GameObject.Find("StatusBar");
        statusBar = statusBarScript.GetComponent<StatusBar>();

        userPositionScript = GameObject.Find("CameraPosition");
        userPosition = userPositionScript.GetComponent<UserPosition>();

        loginScript = GameObject.Find("Login");
        login = loginScript.GetComponent<Login>();
    }

    public UserPosition UserPosition
    {
        get
        {
            return userPosition;
        }

    }

    public Login Login
    {
        get
        {
            return login;
        }

    }

    public StatusBar StatusBar
    {
        get
        {
            return statusBar;
        }

    }

    public void checkPosition()
    {
        string url = "http://" + ip + "/Unity_apply/controller.php";

        WWWForm form = new WWWForm();
        form.AddField("username", Login.Username);
        form.AddField("Job","CheckPosition");
        WWW www = new WWW(url, form);

        StartCoroutine(PositionStatus(www));
    }

    public void loadingScenes(string levelName)
    {
        sceneLoading = SceneManager.LoadSceneAsync(levelName);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadSceneWait());
    }
 
    //Change position from the camera with the received new position from the database
    public void changeCameraPosition()
    {
        UserPosition.CameraPosition = new Vector3(X, Y, Z);
        GameObject camera = GameObject.Find("CardboardMain");
        camera.transform.position = UserPosition.CameraPosition;
    }

    IEnumerator LoadSceneWait()
    {
        while (sceneLoading.progress < 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log(sceneLoading.progress);
            Debug.Log("progress");
        }

        sceneLoading.allowSceneActivation = true;
        Debug.Log("Done loading");

        if (sceneLoading.allowSceneActivation == true && SceneManager.GetActiveScene().name == "Game")
        {
            Debug.Log("in");
            Login.logged = true;
            Login.CurrentMenu = null;
        }
        else
        {
            Debug.Log("Nope");
        }
    }

    IEnumerator PositionStatus(WWW www)
    {
        yield return www;

        if (www.text == "empty")
        {
            Debug.Log("New account, empty positions var");
        }
        else
        {
            string[] position = www.text.Split(',');

            //assign the numbers to new position camera variables
            X = float.Parse(position[0]);
            Y = float.Parse(position[1]);
            Z = float.Parse(position[2]);
            sceneName = (position[3]);

            if (sceneName == "Game")
            {
               changeCameraPosition();
            }
            else
            {
                loadingScenes(sceneName);

                if (sceneLoading.isDone == true)
                {
                    changeCameraPosition();
                }
            }
        }
    }

}//End Class SwitchingScenes