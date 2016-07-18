using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBarModel : MonoBehaviour
{

    /*
    * Created by Anny Aidinian.
    * 
    * Class that retrieves data from the database. 
    * And sends it to the class that request the data.
    */


    private MainInfo mainInfo;
    public string Feedback = null;
    public int score;
    public string username, InfoStatusbar, InfoStatusbarScore;



    void Start()
    {
        mainInfo = new MainInfo();
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

        mainInfo.ServerConnection(form);

        StartCoroutine(userInfo(mainInfo.WWW));

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
