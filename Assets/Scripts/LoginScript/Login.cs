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
    public string Feedback = "";
    public Texture2D MessageBox = null;
    public string Username, CUsername;
    private MainInfo mainInfo;

    //Private Variables
    private string currentMenu;
    private string password = "";
    private string cpassword = "";
    private string ConfirmPassword = "";

    #endregion variables

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {
    
        CurrentMenu = "Login";
        mainInfo = new MainInfo();

    }

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

    //draws de GUI in unity when Currentmenu isnt empty
    void OnGUI()
    {
        GUI.skin.box.normal.background = MessageBox;

        if (CurrentMenu == "Login" && logged != true)
        {
            LoginGUI();
        }
        else if (CurrentMenu == "CreateAccount")
        {
            CreateAccountGUI();
        }


        if (Feedback != "")
        {
            FeedbackGUI();
        }
    }

    //switches scene to users last visited one
    public void LoggedIn()
    {
        if (SceneManager.GetActiveScene().name == "Garage" && logged == true)
        {
            Debug.Log("succes");
        }
    }

   public void LoginGUI()
    {
        GUI.Box(new Rect(235, 55, 225, 222), "Login");

        GUI.Label(new Rect(253, 86, 170, 21), "Username:");
        Username = GUI.TextField(new Rect(253, 106, 170, 21), Username);

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

    public void CreateAccountGUI()
    {

        GUI.Box(new Rect(235, 75, 225, 222), "Create Account");

        GUI.Label(new Rect(253, 86, 170, 21), "Name:");
        CUsername = GUI.TextField(new Rect(253, 106, 170, 21), CUsername);

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        cpassword = GUI.PasswordField(new Rect(252, 151, 170, 23), cpassword, "*"[0], 25);

        GUI.Label(new Rect(252, 181, 170, 23), "Confirm Password:");
        ConfirmPassword = GUI.PasswordField(new Rect(252, 209, 170, 23), ConfirmPassword, "*"[0], 25);

        if (GUI.Button(new Rect(344, 243, 111, 25), "Create Account"))
        {
            if (CPassword == ConfirmPassword)
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

   public void FeedbackGUI()
    {
        GUI.Box(new Rect(235, 103, 225, 111), Feedback);

        if (GUI.Button(new Rect(287, 164, 111, 25), "Okay"))
        {
            Feedback = "";
        }
    }

}//End Class


