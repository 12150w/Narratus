/*
 * Game Client
 * 
 * A game client is used to connect to a GameServer.
 * It fascilitates the game progress and downloads the story content
 * from the GameServer.
 */
using UnityEngine;
using UnityEngine.Networking;

public class GameClient : ScriptableObject {

    // client is the underlying NetworkClient that is used by the GameClient
    private NetworkClient client = new NetworkClient();

    // GameClient Constructor that sets up the NetworkClient
    public GameClient() {
        client.RegisterHandler(MsgType.Connect, OnConnected);
        client.RegisterHandler(MsgType.Error, OnError);
    }
    
    // Join connects to a network game GameServer
    public void Join(NetworkGame game) {
        client.Connect(game.hostAddress, GameServer.PORT);
    }

    // OnConnected is run when the client connects to the server, it sends the joined message
    public void OnConnected(NetworkMessage netMessage) {
        JoinedMessage joinedMsg = new JoinedMessage();
        joinedMsg.name = "Sample Name";
        client.Send(CustomMessages.JOINED, joinedMsg);
    }

    // OnError is run when the client generates an error
    public void OnError(NetworkMessage netMessage) {
        Debug.LogError(netMessage);
    }

}
