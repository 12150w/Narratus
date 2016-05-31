/*
 * Joined Message (CustomMessages.JOINED)
 * 
 * This message is sent from the client, with the connection id, to tell
 * the server that the player has joined the game.
 */
using UnityEngine.Networking;

public class JoinedMessage : MessageBase {

    // name is the player name that joined
    public string name;

}
