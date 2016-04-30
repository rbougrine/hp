using UnityEngine;
using System.Collections;
using System;

public class Login : MonoBehaviour
{

    #region variables

    //Static Variables
    public static string Name = "";
    public static string Password = "";
  
    //Public Variables
    public string CurrentMenu = "Login";

    //Private Variables
     private string CreateAccountUrl = "";
     private string LoginUrl = "";
     private string CName = "";
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
            CreateAccountGUI();

        }

    }//End OnGUI method

    void LoginGUI()
    {
        GUI.Box(new Rect(235, 55, 225, 222), "Login");

        if (GUI.Button(new Rect(242, 223, 111, 25), "Create Account"))
        {
            CurrentMenu = "CreateAccount";
        }
     

        if (GUI.Button(new Rect(357, 223, 90, 25), "Log in"))
        {
           

        }
        GUI.Label(new Rect(253, 86, 170, 21), "Name:");
        Name = GUI.TextField(new Rect(253, 106, 170, 21), "");

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        Password = GUI.TextField(new Rect(252, 151, 170, 23), "");
    }//End LoginGUI method

    void CreateAccountGUI()
    {

        GUI.Box(new Rect(235, 75, 225, 222), "Create Account");

        GUI.Label(new Rect(253, 86, 170, 21), "Name:");
        CName = GUI.TextField(new Rect(253, 106, 170, 21), "");

        GUI.Label(new Rect(252, 128, 170, 23), "Password:");
        CPassword = GUI.TextField(new Rect(252, 151, 170, 23), "");

        GUI.Label(new Rect(252, 181, 170, 23), "Confirm Password:");
        ConfirmPassword = GUI.TextField(new Rect(252, 209, 170, 23), "");

        if (GUI.Button(new Rect(242, 243, 111, 25),"Create Account"))
        {
            if (CPassword == ConfirmPassword)
            {
                StartCoroutine(CreateAccount());
            }
        }


        if (GUI.Button(new Rect(357, 243, 90, 25), "Back"))
        {
            CurrentMenu = "Login";

        }


    }//End CreateAccountGUI method

    IEnumerator CreateAccount()
    {
        WWWForm Form = new WWWForm();
        Form.AddField("Name",CName);
        Form.AddField("Password", CPassword);

        WWW CreateAccountWWW = new WWW(CreateAccountUrl, Form);

        yield return CreateAccountWWW;

        if (CreateAccountWWW.error != null)
        {
            Debug.LogError("Cannot connect to Account Creation");
        }
        else {
            string CreateAccountReturn = CreateAccountWWW.text;
            if (CreateAccountReturn == "Success")
            {
                Debug.Log("Success: Account created");
                CurrentMenu = "Login";
            }
        }
    }
}//End Class