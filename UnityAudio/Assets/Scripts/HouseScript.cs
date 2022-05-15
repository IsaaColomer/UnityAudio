using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HouseScript : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioMixerGroup> mixers;

    void Awake()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < mixers.Count; i++)
        {
            if(i != 4)
            {
                mixers[i].audioMixer.SetFloat("Volume " + i.ToString(), -20.00f);
                Debug.Log(mixers[i].name);
            }
            
        }

        mixers[4].audioMixer.SetFloat("Volume 4", 6.00f);
        audioSource.Play();
        Debug.Log("La cansionsita se esta reprodusiendo");
        
        
    }

    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < mixers.Count; i++)
        {
            if(i != 4)
            {
                mixers[i].audioMixer.SetFloat("Volume " + i.ToString(), 0f);
                Debug.Log(mixers[i].name);
            }
            else
            {
                mixers[i].audioMixer.SetFloat("Volume " + i.ToString(), -20.00f);
            }
        }

        audioSource.Stop();
        
    }
}
