using System.Collections;


/// <summary>
/// Interface that handles door interaction.
/// </summary>

interface IDoor
{

    void ClickedOnDoor();

    IEnumerator DoorMovement();

}