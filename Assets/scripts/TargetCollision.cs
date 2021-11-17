using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class TargetCollision : MonoBehaviour
{
    private bool beenHit = false;
    private Animation targetRoot;

    public AudioClip hitSound;
    public AudioClip resetSound;
    public float resetTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision theObject)
    {
        if (beenHit == false && theObject.gameObject.name == "Coconut")
        {
            StartCoroutine("targetHit");
        }
    }

    IEnumerator targetHit()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetRoot.Play("down");
        beenHit = true;
        CoconutWin.targets++;
        yield return new WaitForSeconds(resetTime);
        gameObject.GetComponent<AudioSource>().PlayOneShot(resetSound);
        targetRoot.Play("up");
        beenHit = false;
        CoconutWin.targets--;
    }
}
