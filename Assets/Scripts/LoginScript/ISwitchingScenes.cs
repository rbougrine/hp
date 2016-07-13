using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.LoginScript
{
    interface ISwitchingScenes
    {
        void CheckPosition();

        void LoadingScenes(string levelName);

        void ChangeCameraPosition();

        void changePosition();



    }
}
