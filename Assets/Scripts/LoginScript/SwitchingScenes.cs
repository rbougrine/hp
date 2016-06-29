using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchingScenes : MonoBehaviour
{
    //private variables
    private readonly string ip = "145.24.222.160";
    private UserPosition userPosition;
    private Login login;
    private GameObject userPositionScript, loginScript;
   
    //public variables
    public AsyncOperation sceneLoading;
    public string sceneName;

    //camera position
    float X;
    float Y;
    float Z;

   
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
   
    // Use this for initialization
    void Start()
    {
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

    public void CheckPosition()
    {
        string url = "http://" + ip + "/Unity_apply/controller.php";
        WWWForm form = new WWWForm();
        form.AddField("Username", Login.Username);
        form.AddField("Job","CheckPosition");
        WWW www = new WWW(url, form);

        StartCoroutine(PositionStatus(www));
    }

    public void LoadingScenes(string levelName)
    {
        sceneLoading = SceneManager.LoadSceneAsync(levelName);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadSceneWait());
    }
 
    //Change position from the camera with the received new position from the database
    public void ChangeCameraPosition()
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
            Debug.Log("progress:" + sceneLoading.progress);
        }

        sceneLoading.allowSceneActivation = true;
        Debug.Log("Done loading");
        changePosition();
    }

    public void changePosition()
    {
        if (sceneLoading.allowSceneActivation == true && SceneManager.GetActiveScene().name == sceneName)
        {
            userPositionScript = GameObject.Find("UserPosition");
            userPosition = userPositionScript.GetComponent<UserPosition>();

            if (X != 0.0F)
            {
                ChangeCameraPosition();
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Game")
                {
                    X = 536.1f;
                    Y = 12f;
                    Z = 578f;
                    ChangeCameraPosition();
                }
                else
                {
                    X = -237f;
                    Y = -38f;
                    Z = -102f;
                    ChangeCameraPosition();
                }

            }
        }
        else
        {
            Debug.Log("still waiting");
            Debug.Log(SceneManager.GetActiveScene().name);
        }
    }
    

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
         
            //assign the numbers to new position camera variables
            X = float.Parse(position[0]);
            Y = float.Parse(position[1]);
            Z = float.Parse(position[2]);
            sceneName = (position[3]);

            LoadingScenes(sceneName);

                           
        }
    }

}//End Class SwitchingScenes