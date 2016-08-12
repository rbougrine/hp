using UnityEngine;
using UnityEngine.SceneManagement;

class YesButton : IButton
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// manages the yes button
    /// </summary>

    private string sceneName;
    private MainInfo mainInfo;
   
    /// <summary>
    /// Used for initialization
    /// </summary>

    public YesButton()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Handles the scene switching
    /// </summary>

    public void ClickedOn()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Game")
        {
            mainInfo.SwitchingScenes.LoadingScenes("Garage");
        }
        else if (sceneName == "Garage")
        {
            mainInfo.SwitchingScenes.LoadingScenes("Game");
        }
        else
        {
            Debug.Log("Can't find world");
        }
    }
}

