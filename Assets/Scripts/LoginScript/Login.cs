using UnityEngine;

public class Login : MonoBehaviour, ILogin
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that handles logging into the game.
    /// Implements the interface ILogin.
    /// </summary>

    #region variables

    //Public Variables
    public MainInfo mainInfo;
    public Texture2D messageBox;
    public string cUsername;
    public bool logged;

    //Private Variables
    private string username = "";
    private string password = "";
    private string cPassword = "";
    private string confirmPassword = "";
    private string currentMenu, feedback;

    #endregion variables

    /// <summary>
    /// Causes the GameObject not to be removed 
    /// when the scene changes in the game
    /// </summary>

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Used for initialization.
    /// </summary>

    void Start()
    {
        CurrentMenu = "Login";
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Calls the needed GUI method only if CurrentMenu and/or Feedback isn't null.
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
            mainInfo.LoginController.Authorization(username,password);
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
        cPassword = GUI.PasswordField(new Rect(252, 151, 170, 23), cPassword, "*"[0], 25);
        GUI.Label(new Rect(252, 181, 170, 23), "Confirm Password:");
        confirmPassword = GUI.PasswordField(new Rect(252, 209, 170, 23), confirmPassword, "*"[0], 25);
        if (GUI.Button(new Rect(344, 243, 111, 25), "Create Account"))
        {
            if (cPassword == confirmPassword)
            {
                mainInfo.LoginController.Register(cUsername,cPassword);
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

    /// <summary>
    /// Getter and setter for the CurrentMenu string.
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

    /// <summary>
    /// Getter and setter for the Feedback string.
    /// </summary>

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

    /// <summary>
    /// Getter for the Username string.
    /// </summary>

    public string Username
    {
        get
        {
            return username;
        }
    }
}