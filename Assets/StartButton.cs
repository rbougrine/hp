using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

 
    public Texture[] exercise;
    public Texture begin;
    public Texture one;
    public Texture two;
    public Texture three;
    public GameObject manager;
    private ExerciseChanger changer;
    public int number;
    public GameObject DoneButton;
    private DoneButton done;
    public int[] currentExercise;

    // Use this for initialization
    void Start ()
    {
        done = DoneButton.GetComponent<DoneButton>();
        changer = manager.GetComponent<ExerciseChanger>();
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


    public Texture GiveTexture(int indicator)
    {
        return exercise[indicator];
    }

    // Update is called once per frame
    void Update ()
    {
       
    }

    public void exerciseChooser()
    {
        if (number == 1)
        {
            currentExercise = done.exerciseOne;
        }
        else if (number == 2)
        {
            currentExercise = done.exerciseTwo;
        }
        else
        {
            currentExercise = done.exerciseThree;
        }

    }

    public void beginState()
    {
        number = Random.Range(1, 4);
        exerciseChooser();
        switch (number)
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







}
