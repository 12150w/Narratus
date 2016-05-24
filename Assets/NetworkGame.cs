using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkGame : MonoBehaviour {

    // label is the label text for this game
    public Text label;

    // gameName is the game's name
    private string gameName;

    // hostAddress is the ip address of the game's host
    private string hostAddress;

    // Construct a NetworkGame from a given broadcast data and ip address
    public NetworkGame(string hostAddress, string data) {
        this.gameName = data;
        this.hostAddress = hostAddress;
    }

	// Use this for initialization
	void Start () {
	    label.text = gameName + " (" + hostAddress + ")";
	}

}
