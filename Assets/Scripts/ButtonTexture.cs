using System.Collections.Generic;
using UnityEngine;

public class ButtonTexture : MonoBehaviour
{

    public Texture start, done, yes, no, cheat, stop, next;
    Dictionary<string, Texture> buttonTexture =  new Dictionary<string, Texture>();

    void Awake()
    {
        buttonTexture.Add("Start",start);
        buttonTexture.Add("Done", done);
        buttonTexture.Add("Cheat", cheat);
        buttonTexture.Add("Yes", yes);
        buttonTexture.Add("No", no);
        buttonTexture.Add("Stop", stop);
        buttonTexture.Add("Next", next);
    }


    public Texture GiveTexture(string buttonName)
    {
      Texture wantedTexture = buttonTexture[buttonName];
      return wantedTexture;
    }

}

