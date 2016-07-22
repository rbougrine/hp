using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.LoginScript;
using Assets.Scripts.Interfaces;

public class Login : MonoBehaviour, ILogin
{
    #region variables

    //Public Variables
    public bool logged;
    public Texture2D messageBox;
    public string cUsername;
    public MainInfo mainInfo;

    //Private Variables
    private string currentMenu;
    private string feedback;
    private string username = "";
    private string password = "";
    private string cpassword = "";
    private string confirmPassword = "";

    #endregion variables

    /// <summary>
    /// Causes that attached GameObject Login
    /// is still available when scene is changed
    /// </summary>

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Used for initialization
    /// </summary>
   
    void Start()
    { 
        CurrentMenu = "Login";
        mainInfo = new MainInfo();
    }

    /// <summary>
    /// Get and set for other classes to gain acces to the variable needed.
    /// </summary>

    public string CurrentMenu
    {
        get
        {
            return currentMenu;
        }

        set
        {
            currentMenu = value;
        }
    }

    public string Feedback
    {
        get
        {
            return feedback;
        }

        set
        {
            feedback = value;
        }
    }

    public string Username
    {
        get
        {
            return username;
        }

    }

    public string Password
    {
        get
        {
            return password;
        }
  
    }

    public string CPassword
    {
        get
        {
            return cpassword;
        }
    }

    /// <summary>
    /// Calls the needed GUI method when CurrentMenu and/or Feedback isn't null 
    /// </summary>

    void OnGUI()
    {
        GUI.skin.box.normal.background = messageBox;

        if (CurrentMenu == "Login" && logged != true)
        {
            LoginGUI();
        }
        else if (CurrentMenu == "CreateAccount")
        {
            CreateAccountGUI();
        }

        if (Feedback != null)
        {
            FeedbackGUI();
        }
    }

    /// <summary>
    /// Switches scene to users last visited one
    /// </summary>
 
    public void LoggedIn()
    {
        if (SceneManager.GetActiveScene().name == "Garage" && logged == true)
        {
            Debug.Log("succes");
        }
    }


    /// <summary>
    /// Draws the login screen.
    /// </summary>

    public void LoginGUI()
    {
        GUI.Box(new Rect(235, 55, 225, 222), "Login");

        GUI.Label(new Rect(253, 86, 170, 21), "Username:");
        username = GUI.TextField(new Rect(253, 106, 170, 21), username);

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");

        password = GUI.PasswordField(new Rect(252, 151, 170, 23), password, "*"[0], 25);

        if (GUI.Button(new Rect(357, 223, 90, 25), "Log in"))
        {

            mainInfo.Controller.Authorization();

        }

        if (GUI.Button(new Rect(242, 223, 111, 25), "Create Account"))
        {
            CurrentMenu = "CreateAccount";
        }
    }

    /// <summary>
    /// Draws the Register screen.
    /// </summary>

    public void CreateAccountGUI()
    {

        GUI.Box(new Rect(235, 75, 225, 222), "Create Account");

        GUI.Label(new Rect(253, 86, 170, 21), "Name:");
        cUsername = GUI.TextField(new Rect(253, 106, 170, 21), cUsername);

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        cpassword = GUI.PasswordField(new Rect(252, 151, 170, 23), cpassword, "*"[0], 25);

        GUI.Label(new Rect(252, 181, 170, 23), "Confirm Password:");
        confirmPassword = GUI.PasswordField(new Rect(252, 209, 170, 23), confirmPassword, "*"[0], 25);

        if (GUI.Button(new Rect(344, 243, 111, 25), "Create Account"))
        {
            if (CPassword == confirmPassword)
            {
                mainInfo.Controller.Authorization();
            }
            else
            {
                Feedback = "The password is not the same";
            }
        }

        if (GUI.Button(new Rect(245, 243, 90, 25), "Back"))
        {
            CurrentMenu = "Login";

        }

    }

    /// <summary>
    /// Draws the Feedback screen.
    /// </summary>

    public void FeedbackGUI()
    {
        GUI.Box(new Rect(235, 103, 225, 111), Feedback);

        if (GUI.Button(new Rect(287, 164, 111, 25), "Okay"))
        {
            Feedback = null;
        }
    }

}//End Class


