using UnityEngine;
using System.Collections;

public class LoginController : MonoBehaviour {

    private readonly string ip = "145.24.222.160";
    private GameObject loginObject, StatusBarObject;
    private Login login;
    private StatusBar statusBar;
    private SwitchingScenes switchingScenes;
   

    // Use this for initialization
    void Start ()
    {
        loginObject = GameObject.Find("Login");
        StatusBarObject = GameObject.Find("StatusBar");

        login = loginObject.GetComponent<Login>();
        switchingScenes = loginObject.GetComponent<SwitchingScenes>();
        statusBar = StatusBarObject.GetComponent<StatusBar>();
    }

    public Login LoginScript
    {
        get
        {
            return login;
        }

    }

    public SwitchingScenes SwitchingScenes
    {
        get
        {
            return switchingScenes;
        }

    }

    public StatusBar StatusBar
    {
        get
        {
            return statusBar;
        }

    }
    
    //sending the username and password to the database to login into the game
    public void Authorization()
    {
        string url = "http://" + ip + "/LoginAccount.php";

        WWWForm form = new WWWForm();
        form.AddField("Username", LoginScript.Username);
        form.AddField("Password", LoginScript.Password);
        WWW www = new WWW(url, form);

        StartCoroutine(LoginAccount(www));

    }

    //sending the new username and password to the database to register
    public void Register()
    {
        string url = "http://" + ip + "/CreateAccount.php";

        WWWForm form = new WWWForm();
        form.AddField("Username", LoginScript.CUsername);
        form.AddField("Password", LoginScript.CPassword);
        WWW www = new WWW(url, form);
        
        StartCoroutine(CreateAccount(www));
    }

    IEnumerator LoginAccount(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error != null)
        {
             LoginScript.Feedback = www.error;
        }
        else
        {
            if (www.text == "Login successful!")
            {
                LoginScript.logged = true;
                LoginScript.CurrentMenu = null;

                LoginScript.LoggedIn();
                SwitchingScenes.checkPosition();

                StatusBar.Getinfo();
            }
            else
            {
                LoginScript.Feedback = www.text;
            }

        }

    }

    IEnumerator CreateAccount(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error != null)
        {
            LoginScript.Feedback = www.error;
        }
        else
        {
            if (www.text == "Registratie successful")
            {
                LoginScript.Feedback = www.text;
                LoginScript.CurrentMenu = "Login";
            }
            else
            {
                LoginScript.Feedback = www.text;
            }
        }

    }

}//End Class LoginController
