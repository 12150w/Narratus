/*
 * Network Game Finder
 * 
 * This handles finding and starting new network games.
 */
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkGameFinder : NetworkDiscovery {

    // didInit is true if NetworkDiscovery.Initialize() was called
    private bool didInit = false;

    // OnRecievedBroadcast is called when data comes in from the network
    public override void OnReceivedBroadcast(string fromAddress, string data) {
        Debug.Log("Game " + data + "(" + fromAddress + ")");
    }

    // StartHosting starts hosting a game with a certain tag, returns True if broadcast successful
    public bool StartHosting(string tag) {
        this.broadcastData = tag;
        this.VerifyInit();

        return this.StartAsServer();
    }

    // StartListening starts accepting game broadcasts
    public bool StartListening() {
        this.VerifyInit();

        return this.StartAsClient();
    }

    // VerifyInit will initialize the network finder if it hasn't done so already
    private void VerifyInit() {
        if (this.didInit == true) {
            return;
        }

        this.Initialize();
        this.didInit = true;
    }

}
