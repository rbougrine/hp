using UnityEngine;

class NextButton : IButton
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// manages the Next button
    /// </summary>

    private MainInfo mainInfo;
    private int randomNumber;
    private string Parent;

    /// <summary>
    /// Used for initialization
    /// </summary>

    public NextButton()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Randomizing the excercises that will be shown next.
    /// </summary>

    public void ClickedOn()
    {
        Parent = GameObject.Find("Stop").transform.parent.name;
        GameObject.Find(Parent).SetActive(false);
        randomNumber = Random.Range(1, 4);
        mainInfo.Exercise.ExerciseChooser(randomNumber);
        mainInfo.ExerciseChanger.currentExercise = randomNumber;
    }
}

