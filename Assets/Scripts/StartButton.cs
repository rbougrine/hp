using UnityEngine;

public class StartButton : MonoBehaviour, IButton
{

    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// The start button that is used to get the game started
    /// </summary>

    private MainInfo mainInfo;
    private int randomNumber;

    /// <summary>
    /// Used for initialization
    /// </summary>

    public StartButton()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Randomizing the excercises that will be shown.
    /// </summary>

    public void ClickedOn()
    {
        randomNumber = Random.Range(1, 4);
        mainInfo.Exercise.ExerciseChooser(randomNumber);
        mainInfo.ExerciseChanger.currentExercise = randomNumber;
        StartTimer();
    }

    /// <summary>
    /// Starts the timer
    /// </summary>

    void StartTimer()
    {
        mainInfo.PlaytimeModel.StartTimer();
    }

}

