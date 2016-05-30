using UnityEngine;
using System.Collections;

public class PanelMan : MonoBehaviour {


    public Texture[] texture = new Texture[9];
    public Texture one;
    public Texture two;
    public Texture three;
    public Texture four;
    public Texture five;
    public Texture six;
    public Texture seven;
    public Texture eight;
    public Texture empty;
    // Use this for initialization

    void Start()
    {

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


    }

    // Update is called once per frame
    void Update()
    {

    }

    public Texture GiveTexture(int indicator)
    {
        Debug.Log("requesting texture [" + indicator + "]: " + texture[indicator]);
        return texture[indicator];
    }
}

