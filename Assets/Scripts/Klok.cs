using UnityEngine;
using System.Collections;

public class klok : MonoBehaviour {
    // playtime contains the time
    public int playtime = 0;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    private int days = 0; 


	void Start () {

        StartCoroutine("Playtimer");

	}

    private IEnumerator Playtimer() {

        while (true) {
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60;
            hours = (playtime / 3600) % 24;
            days = (playtime / 86400) % 365;


        }

     
    }


    void OnGUi() {
        GUI.Label(new Rect(50, 50, 400, 50), hours.ToString() + minutes.ToString() +  seconds.ToString ());
    }


    }



