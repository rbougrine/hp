using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBar : MonoBehaviour
{
    public string username;

    void Start()
    {
       
    }

    void Update()
    {

    }

   public void getInfo()
    {
        GameObject loginScreen = GameObject.Find("Login");
        Login Login = loginScreen.GetComponent<Login>();
        username = Login.Username;

        if (Login.camera1 == true)
        {
            string url = "http://145.24.222.160/getInfo.php";
            WWWForm form = new WWWForm();
            form.AddField("Username", username);

            WWW www = new WWW(url, form);

            StartCoroutine(userInfo(www));
        }
        else
        {
            Debug.Log("Still logging in");
        }
    }

    IEnumerator userInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
    }

    void onGUI()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Bar();
        }
        else
        {

        }

    }

    void Bar()
    {

        GUI.Box(new Rect(235, 55, 225, 222), "Status Bar");

    }

}//End Class
