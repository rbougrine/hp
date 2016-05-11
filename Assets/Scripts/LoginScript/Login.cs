using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{

    #region variables

    //Static Variables
    public static string Username = "";
    public static string Password = "";
  
    //Public Variables
    public string CurrentMenu = "Login";
    
    //Private Variables
     private string CUsername = "";
     private string CPassword = "";
     private string ConfirmPassword = "";

    //GUI test section
    public float X;
    public float Y;
    public float Width;
    public float Height;

    #endregion variables

    // Use this for initialization
    void Start()
    {

    }//End Start method

    void OnGUI()
    {
        if (CurrentMenu == "Login")
        {
            LoginGUI();

        }
        else if (CurrentMenu == "CreateAccount")
        {

            // For testing purpose createAccountGui disabled
            // CreateAccountGUI();
           
            SceneManager.LoadScene("Splash");

        }

    }//End OnGUI method



    void LoginGUI()
    {
        GUI.Box(new Rect(235, 55, 225, 222), "Login");

        GUI.Label(new Rect(253, 86, 170, 21), "Username:");
        Username = GUI.TextField(new Rect(253, 106, 170, 21), Username);

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        Password = GUI.TextField(new Rect(252, 151, 170, 23), Password);

        if (GUI.Button(new Rect(357, 223, 90, 25), "Log in"))
        {
            string url = "http://localhost/LoginAccountT.php?";

            WWWForm form = new WWWForm();
            form.AddField("Username", Username);
            form.AddField("Password", Password);
            WWW www = new WWW(url, form);

            StartCoroutine(LoginAccount(www));

        }

        if (GUI.Button(new Rect(242, 223, 111, 25), "Create Account"))
        {
            CurrentMenu = "CreateAccount";
        }
    }//End LoginGUI method

    void CreateAccountGUI()
    {

        GUI.Box(new Rect(235, 75, 225, 222), "Create Account");

        GUI.Label(new Rect(253, 86, 170, 21), "Name:");
        CUsername = GUI.TextField(new Rect(253, 106, 170, 21), CUsername);

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        CPassword = GUI.TextField(new Rect(252, 151, 170, 23), CPassword);

        GUI.Label(new Rect(252, 181, 170, 23), "Confirm Password:");
        ConfirmPassword = GUI.TextField(new Rect(252, 209, 170, 23), ConfirmPassword);

        if (GUI.Button(new Rect(242, 243, 111, 25),"Create Account"))
        {
            if (CPassword == ConfirmPassword)
            {
                string url = "http://localhost/CreateAccountT.php?";

                WWWForm form = new WWWForm();
                form.AddField("Username", CUsername);
                form.AddField("Password", CPassword);
                WWW www = new WWW(url, form);

                StartCoroutine(CreateAccount(www));
                CurrentMenu = "Login";
            }
            else
            {
                Debug.Log("The password is not correctly entered");
            }
        }


        if (GUI.Button(new Rect(357, 243, 90, 25), "Back"))
        {
            CurrentMenu = "Login";

        }


    }//End CreateAccountGUI method

    IEnumerator CreateAccount(WWW www)
    {
        yield return www;

         // check for errors
        if (www.error == null)
        {
            Debug.Log(www.text);
          


        }
        else
        {
            Debug.Log("Error: " + www.error);
        }
    }//End CreateAccount

    IEnumerator LoginAccount(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log(www.text);


        }
        else
        {
            Debug.Log("Error: " + www.error);
        }

    }//End LoginAccount

}//End Class