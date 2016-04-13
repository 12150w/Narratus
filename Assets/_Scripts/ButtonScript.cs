using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ButtonScript : NetworkBehaviour 
{
    
    public GameObject gameController;
    
	[Command]
    public void Cmd_Toggle()
    {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
    }
}
