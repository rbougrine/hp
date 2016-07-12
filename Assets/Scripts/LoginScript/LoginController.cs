using UnityEngine;
using System.Collections;

public class LoginController : MonoBehaviour {

    private MainInfo mainInfo;

    // Use this for initialization
    void Start()
    {
        mainInfo = new MainInfo();
    
    }


    //sending the username and password to the database to login into the game
    public void Authorization()
    {
      

        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.Username);
        form.AddField("Password", mainInfo.Login.Password);
        form.AddField("Job", "LoginAccount");
        WWW www = new WWW(mainInfo.URL, form);

        StartCoroutine(LoginAccount(www));

    }

    //sending the new username and password to the database to register
    public void Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", mainInfo.Login.CUsername);
        form.AddField("Password", mainInfo.Login.CPassword);
        form.AddField("Job", "RegisterAccount");
        WWW www = new WWW(mainInfo.URL, form);
        
        StartCoroutine(CreateAccount(www));
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
                mainInfo.Login.CurrentMenu = null;
                
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
                mainInfo.Login.CurrentMenu = "Login";
            }
            else
            {
                mainInfo.Login.Feedback = www.text;
            }
        }

    }

}//End Class LoginController
