using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserPosition : MonoBehaviour
{

    public string sceneName;
    string username;

    private Vector3 CameraPosition = GameObject.Find("CardboardMain").transform.position;
   
    //Current camera position
    string x;
    string y;
    string z;
   
    //New camera position
    public float X;
    public float Y;
    public float Z;

    CardboardHead head;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void collectInfo()
    {
      
        x = CameraPosition.x.ToString("0.00");
        y = CameraPosition.y.ToString("0.00");
        z = CameraPosition.z.ToString("0.00");

        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        GameObject statusBarScript = GameObject.Find("StatusBar");
        StatusBar StatusBar = statusBarScript.GetComponent<StatusBar>();

        username = StatusBar.username;

        retrieveInfo();
    }

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

    void retrieveInfo()
    {
        string url = "http://145.24.222.160/retrievePosition.php";

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("sceneName",sceneName);
        WWW www = new WWW(url, form);

        StartCoroutine(getInfo(www));

    }

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
            Debug.Log(www.text + "saveInfo");
        }

    }

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
    

    public void changeCameraPosition()
    {
     
       CameraPosition = new Vector3(X,Y,Z);
     
        GameObject camera = GameObject.Find("CardboardMain");
        camera.transform.position = CameraPosition;
      

    }
}
