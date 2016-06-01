using UnityEngine;
using System.Collections;

public class PanelMan : MonoBehaviour
{

    public Texture[] texture;
    public int[] userInput;
    public Texture one;
    public Texture two;
    public Texture three;
    public Texture four;
    public Texture five;
    public Texture six;
    public Texture seven;
    public Texture eight;
    public Texture nine;
    public Texture ten;
    public Texture empty;
    int countWrong, countGood;
    // Use this for initialization
    void Start()
    {
        texture = new Texture[11];
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
      //  Debug.Log(exerciseOne[]);
    }


        // Update is called once per frame
        void Update()
    {

    }

    public Texture GiveTexture(int indicator)
    {
        //  Debug.Log("requesting texture [" + indicator + "]: " + texture[indicator]);
        return texture[indicator];
    }

   public void readState()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
       
        userInput = new int[allChildren.Length - 1];

        for (int i = 1; i < allChildren.Length; i++)
        {
        
            userInput[i-1] = allChildren[i].GetComponent<PipePanelChanger>().currentStatus;
        }
      

    }

    public bool checkArray(int[] userInput, int[] exerciseOne)
    {
       
        if (exerciseOne.Length != userInput.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < exerciseOne.Length; i++)
            {
                if (exerciseOne[i] != userInput[i])
                {
                    countWrong++;

                } else if (exerciseOne[i] == userInput[i])
                {
                    countGood++;
                }
            }
            if (countGood == 25)
            {
                Debug.Log("Good job");

            }
            else
            {
                Debug.Log("Try again");
                Debug.Log(countGood+""+countWrong);
            }


        }
      
            return true;

    }



}

