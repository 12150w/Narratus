/*
 * Game Server
 * 
 * The network server is run when hosting a game.
 * It manages the game progress by synchronizing all players.
 * It is also responsible for distributing the story at the beginning of the game.
 */
using UnityEngine;
using UnityEngine.Networking;

public class GameServer : ScriptableObject {

	// PORT is the port number the server operates on
    public static readonly int PORT = 40404;

    // GameServer Constructor sets up message handlers for the NetworkServer
    public GameServer() {
        NetworkServer.RegisterHandler(CustomMessages.JOINED, OnJoined);
    }

    // Listen runs the server, binding to the PORT
    public void Listen() {
        NetworkServer.Listen(PORT);
    }

    // OnJoined is called when a JOINED message is recieved
    public void OnJoined(NetworkMessage netMessage) {
        JoinedMessage message = netMessage.ReadMessage<JoinedMessage>();

        Debug.Log("Player Joined: " + message.name);
    }

}
