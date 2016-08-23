using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBarModel : MonoBehaviour
{
    /// <summary>
    /// Created by Anny Aidinian
    /// Class that retrieves data from the database. 
    /// And sends it to the class that request the data.
    /// </summary>

    private MainInfo mainInfo;
    private ConfigureServer configureServer;
    public string feedback = null;
    public int score;
    public string username, infoStatusbar, infoStatusbarScore;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
        configureServer = new ConfigureServer();
        Getinfo();
    }

    /// <summary>
    /// Fetches the data using the username.
    /// Given by the login class
    /// </summary>

    void Getinfo()
    {
        username = mainInfo.Login.Username;

        WWWForm form = new WWWForm();
        form.AddField("Username", username);
        form.AddField("Job", "GetInfo");

        configureServer.ServerConnection(form);

        StartCoroutine(userInfo(configureServer.WWW));
    }

    /// <summary>
    /// Fetches desired parts of the feedback string.
    /// </summary>

    IEnumerator userInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            feedback = www.error;
        }
        else
        {
            feedback = www.text;
            string[] position = feedback.Split(',');
            infoStatusbar = position[0];
            infoStatusbarScore = position[1];

            score = int.Parse(position[1]);

            if (SceneManager.GetActiveScene().name == "Garage")
            {
                mainInfo.PointCounter.Getinformation();
            }
        }
    }
}