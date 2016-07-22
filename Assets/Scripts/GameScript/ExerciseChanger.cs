using UnityEngine;
using System.Collections;

public class ExerciseChanger : MonoBehaviour
{
    /// <summary>
    /// Created by Randa Bougrine & Anny Aidinian.
    /// Class that changes the puzzles pieces of the game.
    /// </summary>

    public int currentExercise;
    public GameObject manager;

    /// <summary>
    ///  Update is called once per frame
    /// </summary>

    void Update()
    {
        Texture texture = manager.GetComponent<StartButton>().GiveTexture(currentExercise);
        GetComponent<Renderer>().material.mainTexture = texture;
    }


}
