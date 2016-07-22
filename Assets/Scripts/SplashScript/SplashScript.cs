using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class that handles the splash process.
/// 
/// Created by Anny Aidinian.
/// </summary>

public class SplashScript : MonoBehaviour
{
    
    public Image loadingBar;
    public Text percent;
    public float loadingTime;

    void Start()
    {
        loadingBar.fillAmount = 0;
    }

    void Update()
    {
        if (loadingBar.fillAmount <= 1)
        {
            loadingBar.fillAmount += 1.0f / loadingTime * Time.deltaTime;
        }
        if (loadingBar.fillAmount == 1.0f)
        {
          //  SceneManager.LoadScene("Game");
            Debug.Log("Splash done get to game");
        }
        percent.text = (loadingBar.fillAmount * 100).ToString("f0");
    }

}