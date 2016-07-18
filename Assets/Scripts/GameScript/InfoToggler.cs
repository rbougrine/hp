using UnityEngine;

public class InfoToggler : MonoBehaviour {

	public GameObject info;


	//Use this for initialization
	void Start()
	{
		HideInfo();
	}

	//Toggles the visibility
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


	public void ShowInfo()
	{
	
		info.SetActive(true);;
	}

	public void HideInfo()
	{
		info.SetActive(false);
	
	}

}