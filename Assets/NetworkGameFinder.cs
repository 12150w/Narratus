/*
 * Network Game Finder
 * 
 * This handles finding and starting new network games.
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkGameFinder : NetworkDiscovery {

    // StatusListener is run when a game is found
    public delegate void StatusListener(string address, string data);

    // gameFindListener is run when a game is found
    public StatusListener gameFindListener;

    // didInit is true if NetworkDiscovery.Initialize() was called
    private bool didInit = false;
    
    // cachedGames are the games that are currently available
    private List<string> cachedGames = new List<string>();

    // OnRecievedBroadcast is called when data comes in from the network
    public override void OnReceivedBroadcast(string fromAddress, string data) {
        if(!cachedGames.Contains(fromAddress)) {
            cachedGames.Add(fromAddress);

            if(gameFindListener != null) {
                gameFindListener(fromAddress, data);
            }
        }
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
