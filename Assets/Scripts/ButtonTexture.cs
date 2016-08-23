using System.Collections.Generic;
using UnityEngine;

public class ButtonTexture : MonoBehaviour
{

    /// <summary>
    /// Created by Randa Bougrine
    /// Class that has the texture of the buttons
    /// </summary>
   
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

    /// <summary>
    /// Method that gets the texture with the string key
    /// from the dictionary
    /// </summary>
    /// <param name="buttonName"></param>
    /// <returns>wanted texture</returns>
  
    public Texture GetTexture(string buttonName)
    {
      Texture wantedTexture = buttonTexture[buttonName];
      return wantedTexture;
    }

}

