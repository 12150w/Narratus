using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkGame : MonoBehaviour {

    // gameName is the game's name
    public string gameName {
        get { return gameName; }
        set {
            if(nameText != null) {
                nameText.text = value;
            }
        }
    }

    // hostAddress is the ip address of the game's host
    public string hostAddress;

    // nameText is the text for the game name
    public Text nameText;

    // menu is the NetworkMenu instance that created this game
    public NetworkMenu menu;

    // Join will connect to the game, creating a GameClient
    public void Join() {
        GameClient client = GameClient.CreateInstance<GameClient>();
        NetworkMenu.client = client;

        client.Join(this);
    }

}
