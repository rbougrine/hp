using UnityEngine;

public class InfoToggler : MonoBehaviour {

    /// <summary>
    /// Class that handles the clicked game object 
    /// to show the desired images
    /// </summary>

    public GameObject info;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
	{
		HideInfo();
	}

    /// <summary>
    /// Toggles the visibility
    /// </summary>

    public void ToggleInfo()
	{
		if (info.activeSelf)
		{
			HideInfo();
		}
		else {
			ShowInfo();
		}
	}

    /// <summary>
    /// Show information
    /// </summary>

	public void ShowInfo()
	{
		info.SetActive(true);;
	}

	public void HideInfo()
	{
		info.SetActive(false);
	
	}

}