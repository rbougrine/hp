using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class NewEditorTest {



        [Test]
        public void Scorescheck()
        {

            var pointcounter = new PointCounter();
            pointcounter.score = 50;
            pointcounter.Addpoints();

            Assert.AreEqual(60, pointcounter.score);


        }


        [Test]
        public void Statusbar()
        {

            var statusbar = new StatusBarModel();
            statusbar.username = "Anny";

            Assert.IsNotEmpty(statusbar.username);


        }


        [Test]
        public void DateTimeCheck()
        {

            var time = new Playedtime();
            time.starttime = time.endtime;
            Assert.AreEqual(time.starttime, time.endtime);



        }


        [Test]
        public void DateTimeCheckNOT()
        {

            var time = new Playedtime();
            time.starttime = time.endtime;
            Assert.AreNotEqual(time.starttime, time.endtime);



        }




        [Test]
        public void cheatest()
        {
            var PanelMan = new PanelMan();
            var question = new DoneButton();

            var exerciseOne = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 2, 0, 0, 0, 16, 8, 11, 14, 11, 6, 0, 0, 0, 0, 0 };
            var cheatbutton = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 2, 0, 0, 0, 16, 8, 11, 14, 11, 6, 0, 0, 0, 0, 0 };
            var test = PanelMan.CheckArray(exerciseOne, cheatbutton);

            Assert.AreEqual(false, test);

        }


    }

