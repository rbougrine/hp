using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DoorScript
{
    interface IDoor
    {
        void ClickedOnDoor();

        IEnumerator DoorMovement();

    }

}
