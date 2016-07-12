using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchingScenes : MonoBehaviour
{
    //private variables
    private MainInfo mainInfo;
   
    //public variables
    public AsyncOperation sceneLoading;
    public string sceneName;
    public bool newScene;
    private Vector3 cameraPosition;
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
        mainInfo = new MainInfo();
    }

    void Update()
    {
        if (newScene)
        {
            cameraPosition = GameObject.Find("CardboardMain").transform.position;
        }
    }

    public void CheckPosition()
    {

        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.Username);
        form.AddField("Job","CheckPosition");
        WWW www = new WWW(mainInfo.URL, form);

        StartCoroutine(PositionStatus(www));
    }

    public void LoadingScenes(string levelName)
    {
        sceneLoading = SceneManager.LoadSceneAsync(levelName);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadSceneWait());
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

    //Change position from the camera with the received new position from the database
    public void ChangeCameraPosition()
    {
        cameraPosition = new Vector3(X, Y, Z);
        GameObject camera = GameObject.Find("CardboardMain");
        camera.transform.position = cameraPosition;
    }

    public void changePosition()
    {
        if (sceneLoading.allowSceneActivation == true && SceneManager.GetActiveScene().name == sceneName)
        {
            if (X != 0.0F)
            {
              ChangeCameraPosition();
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Game")
                {
                    mainInfo.UserPosition.X = 536.1f;
                    mainInfo.UserPosition.Y = 12f;
                    mainInfo.UserPosition.Z = 578f;

                    ChangeCameraPosition();

                }
                else
                {
                    mainInfo.UserPosition.X = -237f;
                    mainInfo.UserPosition.Y = -38f;
                    mainInfo.UserPosition.Z = -102f;

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