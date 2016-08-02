using UnityEngine;


public class StartButton : MonoBehaviour
{

    /// <summary>
    /// Created by Randa Bougrine & Anny Aidinian.
    /// Class that managed the randomizing process
    /// </summary>

    public Texture[] exercise;
    public int[] currentExercise;

    public Texture begin;
    public Texture one, two, three;
    private int randomnumber;
    private MainInfo mainInfo;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
        exercise = new Texture[4];

        exercise[0] = begin;
        exercise[1] = one;
        exercise[2] = two;
        exercise[3] = three;
    }

    /// <summary>
    /// Gives the needed texture when given the index
    /// </summary>

    public Texture GiveTexture(int indicator)
    {
        return exercise[indicator];
    }

    /// <summary>
    /// Starts the timer
    /// </summary>

    public void Starttijd()
    {
        mainInfo.PlaytimeModel.StartTimer();
    }

    /// <summary>
    /// Randomizing the excercises that will be shown
    /// </summary>

    public void BeginState()
    {
        randomnumber = Random.Range(1, 4);
        ExerciseChooser();
        mainInfo.ExerciseChanger.currentExercise = randomnumber;
    }

    /// <summary>
    /// Manages which exercise is assigned to the random number 
    /// </summary>

    public void ExerciseChooser()
    {
        switch (randomnumber)
        {
            case 1:
                currentExercise = mainInfo.DoneButton.exerciseOne;
                break;
            case 2:
                currentExercise = mainInfo.DoneButton.exerciseTwo;
                break;
            case 3:
                currentExercise = mainInfo.DoneButton.exerciseThree;
                break;
        } 
    }
}








