using UnityEngine;
using System.Collections;

public class ExerciseChanger : MonoBehaviour
{

    /*
     * Created by Randa Bougrine & Anny Aidinian.
     * 
     * Class that changes the puzzles pieces of the game.
     * 
     */


    public int currentExercise;
    public GameObject manager;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Texture texture = manager.GetComponent<StartButton>().GiveTexture(currentExercise);
        GetComponent<Renderer>().material.mainTexture = texture;
    }


}
