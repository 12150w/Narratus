/*
 * Network Menu
 * 
 * Controls the main network menu
 */
using UnityEngine;
using UnityEngine.UI;

public class NetworkMenu : MonoBehaviour {

    // StatusText is the network loading status text
    public Text StatusText;

    // GameName is the name of the game if hosting
    public Text GameName;

    // Finder is the game's network finder
    public NetworkGameFinder Finder;

    // HostGame starts hosting a game
    public void HostGame() {
        bool started = Finder.StartHosting(GameName.text);
        
        if(started != true) {
            Debug.LogError("Failed to start hosting game");
            return;
        }

        StatusText.text = "Hosting Game";
    }

    // JoinGame starts listening for game broadcasts
    public void JoinGame() {
        bool started = Finder.StartListening();

        if(started != true) {
            Debug.LogError("Failed to start listening for games");
            return;
        }

        StatusText.text = "Waiting for games";
    }

}
