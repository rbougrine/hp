using System;
using UnityEngine;

class ConfigureServer
{
    private string ip;
    private string url;
    private WWW www;
    private DefaultGameInformation defaultGameInformation;

    /// <summary>
    /// Constructor fills the ip from defaultGameInformation class
    /// </summary>

    public ConfigureServer()
    {
        defaultGameInformation = new DefaultGameInformation();
        ip = defaultGameInformation.IP;
        url = "http://" + ip + "/Unity_apply/controller.php";
    }

    /// <summary>
    /// try, catch for the server connection
    /// </summary>

    public void ServerConnection(WWWForm form)
    {
        try
        {
            www = new WWW(URL, form);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
    
    public string IP
    {
        get
        {
            return ip;
        }

    }

    public string URL
    {
        get
        {
            return url;
        }

    }

    public WWW WWW
    {
        get
        {
            return www;
        }

    }

}

