using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager_Custom : NetworkManager 
{

	public string IP = "127.0.0.1";
	public int port = 25001;

	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected) {
			if (GUI.Button (new Rect (100, 100, 100, 25), "Start Client")) {
				Network.Connect (IP, port);
			}
			if (GUI.Button (new Rect (100, 125, 100, 25), "Start Server")) {
				Network.Connect (IP, port);
			}
		}
	}

    public void StartupHost()
    {
        SetPort();
		Network.InitializeServer(10, port,false);
    }
    
    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }
    
    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }
    
    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }
}