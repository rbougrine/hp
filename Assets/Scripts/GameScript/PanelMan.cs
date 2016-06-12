using UnityEngine;
using System.Collections;

public class PanelMan : MonoBehaviour
{

    /*
     * Created by Randa Bougrine & Anny Aidinian.
     * 
     * Class managing changes in the panel
     * 
     */

    public Texture[] texture;
    public int[] userInput;
    int countWrong, countGood;
    private string result;

    public Texture one, two, three, four, five, six, seven, eight, nine, ten,
    eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, empty;


    void Start()
    {
        texture = new Texture[18];

        texture[0] = empty;
        texture[1] = one;
        texture[2] = two;
        texture[3] = three;
        texture[4] = four;
        texture[5] = five;
        texture[6] = six;
        texture[7] = seven;
        texture[8] = eight;
        texture[9] = nine;
        texture[10] = ten;
        texture[11] = eleven;
        texture[12] = twelve;
        texture[13] = thirteen;
        texture[14] = fourteen;
        texture[15] = fifteen;
        texture[16] = sixteen;
        texture[17] = seventeen;

    }


    // Update is called once per frame
    void Update()
    {

    }

    public string Result
    {
        get
        {
            return result;
        }
        set
        {
            result = value;
        }


    }

    public Texture GiveTexture(int indicator)
    {
        return texture[indicator];
    }


    /*
    * Resolves the puzzel when triggered  
    */

    public void CheatState(int[] exercise)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        userInput = new int[allChildren.Length - 1];

        userInput = exercise;
        for (int i = 1; i < allChildren.Length; i++)
        {
            allChildren[i].GetComponent<PipePanelChanger>().currentStatus = userInput[i - 1];
        }
    }



    /*
    * Fetch currentstatus state  of user input.
    */
    public void ReadState()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        userInput = new int[allChildren.Length - 1];

        for (int i = 1; i < allChildren.Length; i++)
        {

            userInput[i - 1] = allChildren[i].GetComponent<PipePanelChanger>().currentStatus;
        }


    }




    /*
    * Checks if exerciese is done right
    * by checking user input answer length equals excersie length answer.
    */

    public bool CheckArray(int[] userInput, int[] exercise)
    {
        for (int i = 0; i < exercise.Length; i++)
        {
            // Debug.Log(exercise[i]);

        }
        if (exercise.Length != userInput.Length)
        {
            Result = "wrongLength";
            return false;
        }
        else
        {
            for (int i = 0; i < exercise.Length; i++)
            {
                if (exercise[i] != userInput[i])
                {
                    countWrong++;

                }
                else if (exercise[i] == userInput[i])
                {
                    countGood++;
                }
            }
            if (countGood == 25)
            {
                Result = "GoodJob";
                Debug.Log("GoodJob");
                countWrong = 0;
                countGood = 0;
                return true;

            }
            else
            {
                Result = "TryAgain";
                Debug.Log("Good:" + countGood + "Wrong:" + countWrong);
                countWrong = 0;
                countGood = 0;
                return false;
            }


        }



    }


}

