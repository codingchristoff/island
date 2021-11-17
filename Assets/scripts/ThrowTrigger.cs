using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour
{
    public Image crosshair;
    public Text textHints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        

        if (col.gameObject.tag == "Player")
        {
            CoconutLauncher.canThrow = true;
            crosshair.enabled = true;
            if (!CoconutWin.haveWon)
            {
                textHints.SendMessage("ShowHint", @"There’s a power cell attached to this game,
                maybe I’ll win it if I can knock down all the targets...");
            }
        }            
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        { 
            CoconutLauncher.canThrow = false;
            crosshair.enabled = false;
        }
    }
}
