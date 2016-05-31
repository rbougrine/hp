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
    // Use this for initialization
    void Start()
    {
        texture = new Texture[11];
        texture[0] = empty;
        Debug.Log(texture[0]);
        texture[1] = one;
        Debug.Log(texture[1]);
        texture[2] = two;
        Debug.Log(texture[2]);
        texture[3] = three;
        Debug.Log(texture[3]);
        texture[4] = four;
        Debug.Log(texture[4]);
        texture[5] = five;
        Debug.Log(texture[5]);
        texture[6] = six;
        Debug.Log(texture[6]);
        texture[7] = seven;
        Debug.Log(texture[7]);
        texture[8] = eight;
        Debug.Log(texture[8]);
        texture[9] = nine;
        Debug.Log(texture[9]);
        texture[10] = ten;
        Debug.Log(texture[10]);
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




}

