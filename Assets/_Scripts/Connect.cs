using UnityEngine;
using System.Collections;

public class Connect : MonoBehaviour {

	public string IP = "127.0.0.1";
	public int port = 25001;

	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected) {
			if (GUI.Button (new Rect (100, 100, 100, 25), "Start Client")) {
				Network.Connect (IP, port);
			}
			if (GUI.Button (new Rect (100, 125, 100, 25), "Start Server")) {
				Network.InitializeServer (10, port);
			}
		} else {
			if (Network.peerType == NetworkPeerType.Client) {
				
				GUI.Label (new Rect (100, 100, 100, 25), "Client");

				if (GUI.Button(new Rect (100, 125, 100, 25), "Disconnect")) {
					Network.Disconnect(250);
				}
			}
			if (Network.peerType == NetworkPeerType.Server) {
				
				GUI.Label (new Rect (100, 100, 100, 25), "Server");
				GUI.Label (new Rect (100, 125, 100, 25), "Connections: " + Network.connections.Length);

				if (GUI.Button(new Rect (100, 150, 100, 25), "Disconnect")) {
					Network.Disconnect(250);
				}
			}
		}
	}
}
