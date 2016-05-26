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

}
