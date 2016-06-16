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
    public GameObject manager;
    private ExerciseChanger changer;
    public GameObject DoneButton;
    private DoneButton done;
    private Playedtime timee;
    public GameObject Timerbegin;


    void Start()
    {
        done = DoneButton.GetComponent<DoneButton>();
        changer = manager.GetComponent<ExerciseChanger>();
        timee = Timerbegin.GetComponent<Playedtime>();

        exercise = new Texture[4];
        exercise[0] = begin;
        exercise[1] = one;
        exercise[2] = two;
        exercise[3] = three;


    }

    public ExerciseChanger Changer
    {
        get
        {
            return changer;
        }
    }

    public DoneButton Done
    {
        get
        {
            return done;
        }
    }


    public Playedtime Timee
    {
        get
        {
            return timee;

        }

    }

    public Texture GiveTexture(int indicator)
    {
        return exercise[indicator];
    }




    public void Starttijd()
    {
        timee.StartTimer();
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
                Changer.currentExercise = 1;
                break;
            case 2:
                Changer.currentExercise = 2;
                break;
            case 3:
                Changer.currentExercise = 3;
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
            currentExercise = done.exerciseOne;
        }
        else if (randomnumber == 2)
        {
            currentExercise = done.exerciseTwo;
        }
        else
        {
            currentExercise = done.exerciseThree;
        }

    }

}








