using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    public AudioSource riverAudioSource;
    private bool doOnetime;
    // Start is called before the first frame update
    void Start()
    {
        doOnetime = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!doOnetime)
        {
            riverAudioSource.Play();
            doOnetime = true;
        }
        if(other.tag == "RiverTrigger")
        {
            Debug.Log(other.name + "activated");
            riverAudioSource.transform.position = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
