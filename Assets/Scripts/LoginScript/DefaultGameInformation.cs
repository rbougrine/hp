using System;
using LitJson;
using System.IO;
using UnityEngine;

public class DefaultGameInformation
{
    private string jsonString;
    private JsonData itemData;
    private string ip;
    private Login login;
    private MainInfo mainInfo;
    private float X, Y, Z;

    /// <summary>
    /// Contructor to start reading config file 
    /// </summary>

    public DefaultGameInformation()
    {
        mainInfo = new MainInfo();
        ReadConfig();
    }

    /// <summary>
    /// Read config file
    /// </summary>

    void ReadConfig()
    {
        try
        {
            jsonString = File.ReadAllText(Application.dataPath + "/config.json");
            itemData = JsonMapper.ToObject(jsonString);
            ip = itemData["IP"].ToString();
        }
        catch (FileNotFoundException e)
        {
            login = new Login();
            login.Feedback = "Config file not found.";
            Debug.Log(e);
        }

    }

    /// <summary>
    /// Looping through the config file to put the coordinates into the variable
    /// </summary>

    public void GetCoordinates(string sceneName)
    {
        try
        {
            for (int i = 0; i < 3; i++)
            {             
                float coordinate = float.Parse(itemData[sceneName][i].ToString());
                Coordinates(i, coordinate);
            }
        }
        catch (NullReferenceException ex)
        {
            login.Feedback = "Data not found";
            Debug.Log(ex);
        }
    }

    /// <summary>
    /// Coordinates variables
    /// </summary>

    void Coordinates(int index, float coor)
    {
        switch (index)
        {
            case 0:
                mainInfo.SwitchingScenes.X = coor;
                break;
            case 1:
                mainInfo.SwitchingScenes.Y = coor;
                break;
            case 2:
                mainInfo.SwitchingScenes.Z = coor;
                break;
        }
    }

    public string IP
    {
        get
        {
            return ip;
        }
    }

}