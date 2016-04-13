using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{

    ///// Game Controller Script /////
    ///   Used for controlling game flow
    /// - Stat V // Variables predetermined in Unity interface
    /// - Pan C  // Panel control will select which panel is open
    /// - Tog P  // Toggle Panel will switch objects from active to deactive.
    /// - Dev F  // Develper Function helps the developers easily find which buttons have been set up, and which have not
    ///// Inputs /////
    /// - Buttons
    /// - GameObject references passed in by buttons, or predefined in Unity interface

    /// Stat V

    public GameObject errorMessage;
    public GameObject current;

    /// Pan C

	public void Open(GameObject other) // Note, other is the object passed in via the Unity interface
    {
        current.SetActive(false);
        current = other;
        current.SetActive(true);
    }
    
    /// Dev F

    public void ErrorWrapper()
    {
        errorMessage.SetActive(true);
        StartCoroutine(Error());
    }

    // IEnumerator functions cannot be made public, so we must call them via their "wrapped"

    IEnumerator Error()
    {
        yield return new WaitForSeconds(1f);
        errorMessage.SetActive(false);
    }
    
    public void GetIP(Text text)
    {
        text.GetComponent<Text>().text = Network.player.ipAddress;
    }
}
