using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int charge = 0;
    public AudioClip collectSound;
    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;
    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;
    // Matches
    bool haveMatches = false;
    public Image matchGUI;
    bool fireIsLit = false;

    public Text textHints;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
        meter.material.mainTexture = meterCharge[charge];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CellPickup()
    {
        charge++;
        HUDon();
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        chargeHudGUI.texture = hudCharge[charge];
        meter.material.mainTexture = meterCharge[charge];

    }

    void HUDon()
    {
        if (!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;
        }
    }

    void MatchPickup()
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        matchGUI.enabled = true;
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == "campfire")
        {
            if (haveMatches && !fireIsLit)
            {
                LightFire(col.gameObject);                
            }
            else if (!haveMatches && !fireIsLit)
            {
                textHints.SendMessage("ShowHint", @"I could use this campfire to signal for help..
           if only I could light it..");
            }
        }
    }

    void LightFire(GameObject campfire)
    {
        matchGUI.enabled = false;
        haveMatches = false;
        campfire.GetComponentInChildren<ParticleSystem>().Play();
        campfire.GetComponent<AudioSource>().Play();
        fireIsLit = true;
    }
}
