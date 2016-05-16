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
    public Texture2D MessageBox = null;

    //Private Variables
     private string CUsername = "";
     private string CPassword = "";
     private string ConfirmPassword = "";
     private string Feedback = null;
     

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
        GUI.skin.box.normal.background = MessageBox;

        if (CurrentMenu == "Login")
        {
            LoginGUI();
        }
        else if (CurrentMenu == "CreateAccount")
        {
            CreateAccountGUI();     
        }
    //Feedback messages for the login system
     if (Feedback != null)
        {
            GUI.skin.box.normal.background = MessageBox;
            GUI.Box(new Rect(235, 103, 225, 111), Feedback);

           if (GUI.Button(new Rect(287, 164, 111, 25), "Okay"))
             {
                Feedback = null;
             }

        }
     
    }//End OnGUI method

    
    void LoginGUI()
    {
        GUI.Box(new Rect(235, 55, 225, 222), "Login");

        GUI.Label(new Rect(253, 86, 170, 21), "Username:");
        Username = GUI.TextField(new Rect(253, 106, 170, 21), Username);

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        Password = GUI.PasswordField(new Rect(252, 151, 170, 23), Password, "*"[0], 25);
        
        if (GUI.Button(new Rect(357, 223, 90, 25), "Log in"))
        {
            string url = "http://145.24.222.160/LoginAccountT.php";

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
        CPassword = GUI.PasswordField(new Rect(252, 151, 170, 23), CPassword,"*"[0], 25);

        GUI.Label(new Rect(252, 181, 170, 23), "Confirm Password:");
        ConfirmPassword = GUI.PasswordField(new Rect(252, 209, 170, 23), ConfirmPassword, "*"[0], 25);
   

        if (GUI.Button(new Rect(242, 243, 111, 25),"Create Account"))
        {
            if (CPassword == ConfirmPassword)
            {
                string url = "http://145.24.222.160/CreateAccountT.php";

                WWWForm form = new WWWForm();
                form.AddField("Username", CUsername);
                form.AddField("Password", CPassword);
                WWW www = new WWW(url, form);

                StartCoroutine(CreateAccount(www));
               
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
            
           Feedback = www.text;
           CurrentMenu = "Login";

        }
        else
        {
            Feedback = www.error;
        }
    }//End CreateAccount

    IEnumerator LoginAccount(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Feedback = www.text;
            SceneManager.LoadScene("Splash");

        }
        else
        {
            Feedback = www.error;
            
        }

    }//End LoginAccount

}//End Class