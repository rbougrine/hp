using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
public class StatusBar : MonoBehaviour {
	public  static Login infoScript;
	string username;



	// Use this for initialization
	void Start ()
	{  
		
	}

	public string Username = infoScript.Username;

	public void setUsername(string username )
	{

		this.username = username;

		//Debug.Log(username);	
	}


		
	void Awake(){
	
		DontDestroyOnLoad (this);
	  
	
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log(username);	
	}
	


	void onGUI()
	{
		if (SceneManager.GetActiveScene ().name == "Game") 
		{
			Bar ();		
		}
		else 
		{
			
		}

	}

	void Bar()
	{
	
		GUI.Box(new Rect(235, 55, 225, 222), "Login");

	}

	void getInfo(){
		string url = "http://145.24.222.160/getInfo.php";

		WWWForm form = new WWWForm();
		form.AddField("Username", Username);

		WWW www = new WWW(url, form);
		StartCoroutine(userinfo(www));

	}

	IEnumerator userinfo(WWW www){

		yield return www;

		if (www.error != null) {
			Feedback = www.error;
		} else {
			Feedback = www.text;

		}

}
*/


