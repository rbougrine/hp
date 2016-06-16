using UnityEngine;
using System.Collections;

public class UiManG : MonoBehaviour
{

    /*
    * Created by Anny Aidinian.
    * 
    * Class that draws the GUI of the timer
    * 
    */


    private int playtime = 0;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    public GUIStyle timetyle;
    private Playedtime time;
    public GameObject timer;


    // Use this for initialization
    void Start()
    {

        time = timer.GetComponent<Playedtime>();

    }


    public Playedtime Time
    {
        get
        {
            return time;

        }
    }

    /*
     * Fetches the time.
     * Draws the GUI.
     */

    public void TimerDisplay()
    {

        seconds = time.seconds;
        minutes = time.minutes;
        hours = time.hours;

        GUI.Box(new Rect(250, 150, 260, 20), "PlayedTime = " + hours.ToString() + " Hours:  " + minutes.ToString() + " Minutes:  " + seconds.ToString() + " Secondes  ", timetyle);


    }

}
