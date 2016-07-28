using System;
using LitJson;
using UnityEngine;

public class DefaultGameInformation
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that initializes the default information from the config file
    /// </summary>

    private string jsonString;
    private JsonData itemData;
    private Login login;
    private MainInfo mainInfo;
    private float X, Y, Z;

    /// <summary>
    /// Contructor to start reading config file 
    /// </summary>

    public DefaultGameInformation()
    {
        mainInfo = new MainInfo();
    }

    /// <summary>
    /// Looping through the config file 
    /// to put the coordinates into the variable
    /// in the methode Coordinates()
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
    /// Coordinates variables being filled 
    /// given from the methode GetCoordinates()
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
 }
