using UnityEngine;
using System.Collections;
using System;


public class Playedtime : MonoBehaviour
{
    // playtime contains the time
    public int playtime = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;



    void Start()
    {



    }



    public void startTimer()
    {

        StartCoroutine(Playtimer());
    }



    IEnumerator Playtimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60;
            hours = (playtime / 3600) % 24;

            
        }

    }

    void OnGUI()
    {
        timerDisplay();
    }


    void timerDisplay()
    {
        GUI.Label(new Rect(100, 100, 100, 150), hours.ToString());
        GUI.Label(new Rect(110, 100, 100, 150), minutes.ToString());
        GUI.Label(new Rect(120, 100, 100, 150), seconds.ToString());

        }
    
}
    





