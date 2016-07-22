using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBarModel : MonoBehaviour
{
    /// <summary>
    /// Class that retrieves data from the database. 
    /// And sends it to the class that request the data.
    /// </summary>

    private MainInfo mainInfo;
    private ConfigureServer configureServer;
    public string Feedback = null;
    public int score;
    public string username, InfoStatusbar, InfoStatusbarScore;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = new MainInfo();
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
            Feedback = www.error;
        }
        else
        {
            Feedback = www.text;
            string[] position = Feedback.Split(',');
            InfoStatusbar = (position[0]);
            InfoStatusbarScore = (position[1]);

            score = int.Parse(position[1]);

            if (SceneManager.GetActiveScene().name == "Garage")
            {
                mainInfo.Points.Getinformation();             
            }
        }
    }   
}
