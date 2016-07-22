using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// Class that retrieves data from the database 
/// and sends it to the class that request the data.
/// 
/// Created by Anny Aidinian.
/// </summary>

public class StatusBarModel : MonoBehaviour
{

    public string Feedback = null;
    public string username, InfoStatusbar, InfoStatusbarScore;
    public int score;

    private MainInfo mainInfo;
    private ConfigureServer configureServer;

    void Start()
    {
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();
        Getinfo();
    }

    /*
     * Fetches the data using the username.
     * Given by the login class
     */

    void Getinfo()
    {

        username = mainInfo.Login.Username;

        WWWForm form = new WWWForm();
        form.AddField("Username", username);
        form.AddField("Job", "GetInfo");

        configureServer.ServerConnection(form);

        StartCoroutine(userInfo(configureServer.WWW));

      }

    /*
     * Fetches desired parts of the feedback string.
     */

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