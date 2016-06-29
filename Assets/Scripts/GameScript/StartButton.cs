using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{

    /*
   * Created by Randa Bougrine & Anny Aidinian.
   * 
   * Class that managed the randomizing process
   * 
   */

    public Texture[] exercise;
    public int[] currentExercise;

    public Texture begin;
    public Texture one, two, three;
    public int randomnumber;
    private MainInfo mainInfo;

    void Start()
    {

        mainInfo = new MainInfo();
        exercise = new Texture[4];
        exercise[0] = begin;
        exercise[1] = one;
        exercise[2] = two;
        exercise[3] = three;


    }

    

    public Texture GiveTexture(int indicator)
    {
        return exercise[indicator];
    }




    public void Starttijd()
    {
        mainInfo.Timer.StartTimer();
    }


    /*
    * Randomizing the excercises that will be shown
    */

    public void BeginState()
    {

        randomnumber = Random.Range(1, 4);
        ExerciseChooser();

        switch (randomnumber)
        {
            case 1:
                mainInfo.Changer.currentExercise = 1;
                break;
            case 2:
                mainInfo.Changer.currentExercise = 2;
                break;
            case 3:
                mainInfo.Changer.currentExercise = 3;
                break;

        }

    }


    /*
    * Manages which exercise is assigned to the random number 
    */

    public void ExerciseChooser()
    {
        if (randomnumber == 1)
        {
            currentExercise = mainInfo.Done.exerciseOne;
        }
        else if (randomnumber == 2)
        {
            currentExercise = mainInfo.Done.exerciseTwo;
        }
        else
        {
            currentExercise = mainInfo.Done.exerciseThree;
        }

    }

}








