using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    public AsyncOperation sceneLoading;

    #region variables

    //Public Variables
    public string CurrentMenu = "Login";
	public Texture2D MessageBox = null;
	public string Username = "";
	string Password = "";
	public GameObject camera1;
	public GameObject camera2;
    public GameObject EventSystem;
    public bool loggedIn;
    private GameObject statusBarScript;
    private StatusBar statusBar;
    private GameObject UserPositionScript;
    private UserPosition userPosition;

    //Private Variables
    private string CUsername = "";
	private string CPassword = "";
	private string ConfirmPassword = "";
	private string Feedback = null;

    //camera position
    float X;
    float Y;
    float Z;
    string sceneName;

	//GUI test section
	public float x;
	public float y;
	public float Width;
	public float Height;

	#endregion variables

	void Awake()
	{
		DontDestroyOnLoad (this);
	}


	// Use this for initialization
	void Start()
	{
        statusBarScript = GameObject.Find("StatusBar");
        statusBar = statusBarScript.GetComponent<StatusBar>();
        UserPositionScript = GameObject.Find("CameraPosition");
        userPosition = UserPositionScript.GetComponent<UserPosition>();


    }//End Start method

    public UserPosition UserPosition
    {
        get
        {
            return userPosition;
        }

    }

    public StatusBar StatusBar
    {
        get
        {
            return statusBar;
        }

    }

	void OnGUI()
	{
		GUI.skin.box.normal.background = MessageBox;

        if (CurrentMenu == "Login" && loggedIn != true)
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


     public void inUse()
    {
         if (SceneManager.GetActiveScene().name == "Game" && Username != null)
        {
             camera1.SetActive(false);
             camera2.SetActive(true);
             EventSystem.SetActive(true);
        }
    }

	void LoginGUI()
	{
		GUI.Box(new Rect(235, 55, 225, 222), "Login");

		GUI.Label(new Rect(253, 86, 170, 21), "Username:");
		Username = GUI.TextField(new Rect(253, 106, 170, 21), Username);

		GUI.Label(new Rect(252, 128, 170, 23), "Password:");
		Password = GUI.PasswordField(new Rect(252, 151, 170, 23), Password, "*"[0], 25);

		if (GUI.Button(new Rect(357, 223, 90, 25), "Log in"))
		{
			string url = "http://145.24.222.160/LoginAccount.php";

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
				string url = "http://145.24.222.160/CreateAccount.php";

				WWWForm form = new WWWForm();
				form.AddField("Username", CUsername);
				form.AddField("Password", CPassword);
				WWW www = new WWW(url, form);

				StartCoroutine(CreateAccount(www));

			}
			else
			{
				Feedback = "The password is not the same";
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
		if (www.error != null)
		{
			Feedback = www.error;
		}
		else
		{
            if (www.text == "Registratie successful")
            {
                Feedback = www.text;
                CurrentMenu = "Login";
            }
            else
            {
                Feedback = www.text;
            }
        }

	}//End CreateAccount

	IEnumerator LoginAccount(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error != null)
		{
			Feedback = www.error;
		}
		else
		{
            if (www.text == "Login successful!")
            {
                loggedIn = true;     
                CurrentMenu = null;

                inUse();
                checkPosition();

                StatusBar.getInfo();

            }
            else
            {
                Feedback = www.text;
            }
			
      }
		

	}//End LoginAccount

    void checkPosition()
    {
        string url = "http://145.24.222.160/checkPosition.php";
      
        WWWForm form = new WWWForm();
        form.AddField("username", Username);
        WWW www = new WWW(url, form);

        StartCoroutine(PositionStatus(www));
    }

   public void loadingScenes(string levelName)
    {
        sceneLoading = SceneManager.LoadSceneAsync(levelName);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadSceneWait());


    }

    IEnumerator LoadSceneWait()
    {
        while (sceneLoading.progress < 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log(sceneLoading.progress);
            Debug.Log("progress");
        }
      
        sceneLoading.allowSceneActivation = true;
        Debug.Log("Done loading");
        if (sceneLoading.allowSceneActivation == true && SceneManager.GetActiveScene().name == "Game")
        {
            Debug.Log("in");
            loggedIn = true;
            CurrentMenu = null;
        }
        else
        {
            Debug.Log("Nope");

        }
    }

    IEnumerator PositionStatus(WWW www)
    {
        yield return www;
      
        if (www.text == "empty")
        {
            Debug.Log("New account, empty positions var");
        }
        else
        {
             string[] position = www.text.Split(',');
           
            //assign the numbers to new position camera variables
            UserPosition.X = float.Parse(position[0]);
            UserPosition.Y = float.Parse(position[1]);
            UserPosition.Z = float.Parse(position[2]);
            sceneName = (position[3]);

            if (sceneName == "Game")
            {
                //change camera position
                UserPosition.changeCameraPosition();
            }
            else
            {
                loadingScenes(sceneName);
                if (sceneLoading.isDone == true)
                {
                    UserPosition.changeCameraPosition();
                }
            }
            
        }   
    }

}//End Class


