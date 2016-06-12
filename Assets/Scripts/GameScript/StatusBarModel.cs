using UnityEngine;
using System.Collections;


public class StatusBarModel : MonoBehaviour
{

    /*
    * Created by Anny Aidinian.
    * 
    * Class that retrieves data from the database. 
    * And sends it to the class that request the data.
    */


    public Login login;
    private GameObject logIn;
    public string Feedback = null;
    public int score;
    public string username, InfoStatusbar, InfoStatusbarScore;
    private readonly string ip = "145.24.222.160";


    void Start()
    {

        login = login.GetComponent<Login>();
    }

    public Login Login
    {
        get
        {
            return login;
        }
    }


    /*
     * Fetches the data using the username.
     * Given by the login class
     */

    public void Getinfo()
    {

        username = login.Username;

        string url = "http://" + ip + "/getInfo.php";


        WWWForm form = new WWWForm();
        form.AddField("Username", username);


        WWW www = new WWW(url, form);

        StartCoroutine(userInfo(www));
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



        }
    }

}
