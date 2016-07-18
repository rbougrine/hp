using UnityEngine;
using System.Collections;
using Assets.Scripts.Interfaces;

public class LoginController : MonoBehaviour {

    private MainInfo mainInfo;
    private Login login;

    // Use this for initialization
    void Start()
    {
        login = new Login();
        mainInfo = new MainInfo();  
    }


    //sending the username and password to the database to login into the game
    public void Authorization()
    {
      
        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.Username);
        form.AddField("Password", mainInfo.Login.Password);
        form.AddField("Job", "LoginAccount");

        mainInfo.ServerConnection(form);

        StartCoroutine(LoginAccount(mainInfo.WWW));

    }

    //sending the new username and password to the database to register
    public void Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.CUsername);
        form.AddField("Password", mainInfo.Login.CPassword);
        form.AddField("Job", "RegisterAccount");

        mainInfo.ServerConnection(form);

        StartCoroutine(CreateAccount(mainInfo.WWW));

    }

    IEnumerator LoginAccount(WWW www)
    {
        yield return www;
       
        // check for errors
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

    IEnumerator CreateAccount(WWW www)
    {
        yield return www;

        // check for errors
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
