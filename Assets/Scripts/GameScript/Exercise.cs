using UnityEngine;


public class Exercise : MonoBehaviour
{

    /// <summary>
    /// Created by Randa Bougrine & Anny Aidinian.
    /// Class that managed the randomizing process
    /// </summary>

    public Texture[] exercise;
    public int[] currentExercise;
    public Texture begin, one, two, three;

    private MainInfo mainInfo;
    private int[] exerciseOne;
    private int[] exerciseTwo;
    private int[] exerciseThree;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Awake()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
        exerciseOne = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 2, 0, 0, 0, 16, 8, 11, 14, 11, 6, 0, 0, 0, 0, 0 };
        exerciseTwo = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 1, 15, 0, 0, 0, 16, 16, 0, 0, 0, 2, 8, 11, 11, 14, 11, 6 };
        exerciseThree = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 12, 11, 14, 17, 13, 16, 0, 0, 0, 16, 8, 11, 14, 11, 6 };

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
    /// Manages which exercise is assigned to the random number 
    /// </summary>

    public void ExerciseChooser(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                currentExercise = exerciseOne;
                break;
            case 2:
                currentExercise = exerciseTwo;
                break;
            case 3:
                currentExercise = exerciseThree;
                break;
        } 
    }
}








