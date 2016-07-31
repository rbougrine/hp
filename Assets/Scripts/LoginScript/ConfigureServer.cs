using System;
using UnityEngine;
using LitJson;
using System.IO;

class ConfigureServer
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that gets the needed information from the config file 
    /// </summary>

    private readonly string url;
    private string jsonString;
    private JsonData itemData;
    private WWW www;
    private Login login;
    private DefaultGameInformation defaultGameInformation;

    /// <summary>
    /// Constructor initializes the url when bool is true
    /// </summary>

    public ConfigureServer()
    {
        login = new Login();
        ReadConfig();

        if (ReadConfig())
        {
            try
            {
                url = itemData["IP"].ToString() + itemData["URL"].ToString();
            }
            catch(Exception e)
            {              
                login.Feedback = "Data not found.";
                Debug.Log(e.Message);
            }
        }

     }

    /// <summary>
    /// Method reads the json config file
    /// returns true when succeeded
    /// </summary>

    bool ReadConfig()
    {
        try
        {
            jsonString = File.ReadAllText(Application.dataPath + "/config.json");
            itemData = JsonMapper.ToObject(jsonString);
        }
        catch (FileNotFoundException e)
        {
            login.Feedback = "Config file not found.";
            Debug.Log(e.Message);
            return false;
        }
        return true;
    }

    /// <summary>
    /// try, catch for the server connection
    /// </summary>

    public void ServerConnection(WWWForm form)
    {
        try
        {
            www = new WWW(url, form);
        }
        catch (Exception e)
        {

            login.Feedback = "Can't make connection with the server" + e.Message;
            Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// Getter for the string URL
    /// </summary>

    public string URL
    {
        get
        {
            return url;
        }

    }

    /// <summary>
    /// Getter for the WWW
    /// </summary>

    public WWW WWW
    {
        get
        {
            return www;
        }

    }

}

