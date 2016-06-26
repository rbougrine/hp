using UnityEngine;
using System.Collections;

public class LoginController : MonoBehaviour {

    private readonly string ip = "145.24.222.160";
    private GameObject loginObject, StatusBarObject;
    private Login login;
    private StatusBarModel statusBarModel;
    private SwitchingScenes switchingScenes;
   

    // Use this for initialization
    void Start ()
    {
        loginObject = GameObject.Find("Login");
    //    StatusBarObject = GameObject.Find("StatusBar");

        login = loginObject.GetComponent<Login>();
        switchingScenes = loginObject.GetComponent<SwitchingScenes>();
    //    statusBarModel = StatusBarObject.GetComponent<StatusBarModel>();
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

    public StatusBarModel StatusBarModel
    {
        get
        {
            return statusBarModel;
        }

    }
    
    //sending the username and password to the database to login into the game
    public void Authorization()
    {
        string url = "http://" + ip + "/Unity_apply/controller.php";

        WWWForm form = new WWWForm();
        form.AddField("Username", LoginScript.Username);
        form.AddField("Password", LoginScript.Password);
        form.AddField("Job", "LoginAccount");
        WWW www = new WWW(url, form);

        StartCoroutine(LoginAccount(www));

    }

    //sending the new username and password to the database to register
    public void Register()
    {
        string url = "http://" + ip + "/Unity_apply/controller.php";

        WWWForm form = new WWWForm();
        form.AddField("Username", LoginScript.CUsername);
        form.AddField("Password", LoginScript.CPassword);
        form.AddField("Job", "RegisterAccount");
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
                
                SwitchingScenes.CheckPosition();
               
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
