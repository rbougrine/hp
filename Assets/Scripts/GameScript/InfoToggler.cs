using UnityEngine;

public class InfoToggler : MonoBehaviour {

	public GameObject info;


    //Use this for initialization

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