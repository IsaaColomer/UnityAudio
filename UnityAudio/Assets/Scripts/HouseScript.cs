using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HouseScript : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioMixerGroup> mixers;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < mixers.Count; i++)
        {
            mixers[i].audioMixer.SetFloat("Volume " + i.ToString(), -20.00f);
        }

        audioSource.Play();
        audioSource.volume = 1;
    }

    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < mixers.Count; i++)
        {
            mixers[i].audioMixer.SetFloat("Volume " + i.ToString(), 0f);
        }

        audioSource.Stop();
        audioSource.volume = 0;
    }
}
