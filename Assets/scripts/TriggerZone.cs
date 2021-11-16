using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour
{
    public AudioClip lockedSound;
    public Light doorLight;
    public Text textHints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Inventory.charge == 4)
            {
                transform.Find("door").SendMessage("DoorCheck");
                if (GameObject.Find("chargeUI"))
                {
                    Destroy(GameObject.Find("chargeUI"));
                    doorLight.color = Color.green;
                }
            }
            else if (Inventory.charge > 0 && Inventory.charge < 4)
            {
                string hint = $"This door won’t budge.. guess it needs fully charging - maybe more power cells will help...";
                textHints.SendMessage("ShowHint", hint);
                transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
            }
            else
            {
                textHints.SendMessage("ShowHint", "The generator is off and requires power!");
                transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
                col.gameObject.SendMessage("HUDon");
            }
        }
    }
}
