using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{

	#region variables

	//Public Variables
	public string CurrentMenu = "Login";
	public Texture2D MessageBox = null;
	public string Username = "";
	string Password = "";
	public GameObject camera1;
	public GameObject camera2;


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
		camera1.SetActive (true);
		camera2.SetActive (false);


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
			var result = www.text;
			switch (result)
			{
			case "Registration has been successful":
				Feedback = "Registration has been successful";
				CurrentMenu = "Login";
				break;
			case "One or more field are still empty":
				Feedback = "One or more field are still empty";
				break;
			case "Username is already used":
				Feedback = "Username is already used";
				break;
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
			var result = www.text;
			switch (result)
			{
			case "Login successful!":
                camera1.SetActive (false);
				camera2.SetActive (true);
                CurrentMenu = "";
                checkPosition(); 
                    
                    //Get info for the StatusBar
                    GameObject StatusBarScript = GameObject.Find("StatusBar");
                    StatusBar StatusBar = StatusBarScript.GetComponent<StatusBar>();
                   
                   
                    break;
			case "Invalid password":
				Feedback = "Invalid password";
				break;
			case "Invalid username":
				Feedback = "Invalid username";
				break;
			case "Not everything is filled in":
				Feedback = "Not everything is filled in";
				break;

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

            //get script to change the camera position
            GameObject StatusBarScript = GameObject.Find("CameraPosition");
            UserPosition UserPosition = StatusBarScript.GetComponent<UserPosition>();

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
                SceneManager.LoadScene(sceneName);
                UserPosition.changeCameraPosition();
            }           
            

        }   
    }

}//End Class


