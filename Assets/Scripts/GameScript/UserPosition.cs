using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserPosition : MonoBehaviour
{
    //public variable
    public string sceneName, username, x, y, z;
    public float X, Y, Z;

    //private variable
    private Vector3 cameraPosition;
    private MainInfo mainInfo;

    void Start()
    {
        mainInfo = new MainInfo();
        mainInfo.SwitchingScenes.newScene = true;
    }

    void Update()
    {
        cameraPosition = GameObject.Find("CardboardMain").transform.position;        
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
   // and the username which will be send to retrieveInfo()
    public void collectInfo()
    {             
        x = CameraPosition.x.ToString("0.00");
        y = CameraPosition.y.ToString("0.00");
        z = CameraPosition.z.ToString("0.00");
      
        sceneName = SceneManager.GetActiveScene().name;
        username = mainInfo.StatusBarModel.username;
        
        retrieveInfo();
    }

    //Save the new position data to the database to be saved with the current scene name.
    void sendInfo()
    {
      
        WWWForm form = new WWWForm();

        form.AddField("x", x);
        form.AddField("y", y);
        form.AddField("z", z);
        form.AddField("username", username);
        form.AddField("scene", sceneName);
        form.AddField("Job","SavePosition");

        WWW www = new WWW(mainInfo.URL, form);

        StartCoroutine(saveInfo(www));

    }

    //Get the recent saved position data from the database
    void retrieveInfo()
    {
       
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("sceneName",sceneName);
        form.AddField("Job","RetrievePosition");
        mainInfo.ServerConnection(form);

        StartCoroutine(getInfo(mainInfo.WWW));
    

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
