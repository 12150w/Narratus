/*
 * Network Menu
 * 
 * Controls the main network menu
 */
using UnityEngine;
using UnityEngine.UI;

public class NetworkMenu : MonoBehaviour {

    // statusText is the network loading status text
    public Text statusText;

    // gameName is the name of the game if hosting
    public InputField gameName;

    // hostButton is the button used to host a game
    public Button hostButton;

    // findButton is the button used to find games
    public Button findButton;

    // cancelButton is shown when waiting for players to go back
    public Button cancelButton;

    // hostJoinGroup is the canvas group containing the host join form
    public CanvasGroup hostJoinGroup;

    // startCancelGroup is the canvas group containing the start cancel form
    public CanvasGroup startCancelGroup;

    // Finder is the game's network finder
    public NetworkGameFinder finder;

    // Start sets up the initial menu state
    public void Start() {
        if(hostButton != null) {
            hostButton.enabled = false;
            hostButton.onClick.AddListener(HostGame);
        }
        if(findButton != null) {
            hostButton.enabled = true;
            findButton.onClick.AddListener(JoinGame);
        }

        if(gameName != null) {
            gameName.text = "";
            gameName.onValueChanged.AddListener(ValidateHost);
        }

        if(cancelButton != null) {
            cancelButton.enabled = false;
            cancelButton.onClick.AddListener(CancelWaiting);
        }
        if(startCancelGroup != null) {
            startCancelGroup.alpha = 0;
            startCancelGroup.blocksRaycasts = false;
        }
    }

    // ValidateHost checks if the menu is set up to host a game
    private void ValidateHost(string value) {
        if(value == null || value == "") {
            hostButton.enabled = false;
        } else {
            hostButton.enabled = true;
        }
    }

    // HostGame starts hosting a game
    public void HostGame() {
        bool started = finder.StartHosting(gameName.text);
        
        if(started != true) {
            Debug.LogError("Failed to start hosting game");
            return;
        }

        statusText.text = "Hosting \"" + gameName.text + "\"";
        HideHostJoin();
    }

    // JoinGame starts listening for game broadcasts
    public void JoinGame() {
        bool started = finder.StartListening();

        if(started != true) {
            Debug.LogError("Failed to start listening for games");
            return;
        }

        statusText.text = "Waiting for games";
        HideHostJoin();
    }

    // CancelWaiting stops hosting or listening for a game
    public void CancelWaiting() {
        finder.StopBroadcast();
        if(statusText != null) {
            statusText.text = "";
        }

        ShowHostJoin();
    }

    // HideHostJoin hides the host and join controls
    private void HideHostJoin() {
        if(hostJoinGroup != null) {
            hostJoinGroup.alpha = 0;
            hostJoinGroup.interactable = false;
            hostJoinGroup.blocksRaycasts = false;
        }
        if(cancelButton != null) {
            cancelButton.enabled = true;
        }
        if(startCancelGroup != null) {
            startCancelGroup.alpha = 1;
            startCancelGroup.blocksRaycasts = true;
        }
    }

    // ShowHostJoin shows the host join form group
    private void ShowHostJoin() {
        if(hostJoinGroup != null) {
            hostJoinGroup.alpha = 1;
            hostJoinGroup.interactable = true;
            hostJoinGroup.blocksRaycasts = true;
        }
        if(cancelButton != null) {
            cancelButton.enabled = false;
        }
        if(startCancelGroup != null) {
            startCancelGroup.alpha = 0;
            startCancelGroup.blocksRaycasts = false;
        }
    }

}
