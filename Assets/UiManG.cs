using UnityEngine;
using System.Collections;

public class UiManG : MonoBehaviour {

    private int playtime = 0;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    public GUIStyle timetyle;

    private Playedtime time;
    public GameObject timer;


    // Use this for initialization
    void Start () {

        time = timer.GetComponent<Playedtime>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public Playedtime Time
    {
        get
        {
            return time;

        }
    }


    public void TimerDisplay()
    {
       
        seconds = time.seconds;
        minutes = time.minutes;
        hours = time.hours;

        // displaying timer on screen
        GUI.Box(new Rect(250, 150, 260, 20), "PlayedTime = " + hours.ToString() + " Hours:  " + minutes.ToString() + " Minutes:  " + seconds.ToString() + " Secondes  ", timetyle);


    }

}
