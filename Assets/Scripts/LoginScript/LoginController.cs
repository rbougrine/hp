using UnityEngine;
using System.Collections;


public class LoginController : MonoBehaviour
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class data confirms the data when user wants to login
    /// or register
    /// </summary>

    //private variables
    private MainInfo mainInfo;
    private ConfigureServer configureServer;
    private Login login;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        login = new Login();
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();

    }

    /// <summary>
    /// Sending the username and password to the database to verify the credentials.
    /// Checks with ServerConnection if a valid IP is used before starting the Coroutine.
    /// </summary>

    public void Authorization()
    {

        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.Username);
        form.AddField("Password", mainInfo.Login.Password);
        form.AddField("Job", "LoginAccount");

        configureServer.ServerConnection(form);

        StartCoroutine(LoginAccount(configureServer.WWW));

    }

    /// <summary>
    /// Sending the new username and password to the database to register
    /// Checks with ServerConnection if a valid IP is used before starting the Coroutine.
    /// </summary>

    public void Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.cUsername);
        form.AddField("Password", mainInfo.Login.CPassword);
        form.AddField("Job", "RegisterAccount");

        configureServer.ServerConnection(form);

        StartCoroutine(CreateAccount(configureServer.WWW));

    }

    /// <summary>
    /// Waits for API to send feedback,
    /// When its not an error it will go through with the login procedure.
    /// </summary>

    IEnumerator LoginAccount(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            mainInfo.Login.Feedback = www.error;
        }
        else
        {
            if (www.text == "Login successful!")
            {
                mainInfo.Login.logged = true;
                login.CurrentMenu = null;

                mainInfo.SwitchingScenes.CheckPosition();
            }
            else
            {
                mainInfo.Login.Feedback = www.text;
            }
        }
    }

    /// <summary>
    /// Waits for API to send feedback,
    /// When it's not an error it will go through with the register procedure.
    /// </summary>

    IEnumerator CreateAccount(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            mainInfo.Login.Feedback = www.error;
        }
        else
        {
            if (www.text == "Registratie successful")
            {
                mainInfo.Login.Feedback = www.text;
                login.CurrentMenu = "Login";
            }
            else
            {
                mainInfo.Login.Feedback = www.text;
            }
        }
    }

}//End Class LoginController
