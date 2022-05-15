using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] clipsGrass;
    public AudioClip[] clipsWater;
    public AudioClip[] clipsWood;
    public AudioClip clip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Start()
    {

    }
    public void PlayStep()
    {
        audioSource.PlayOneShot(clip);
    }

    //public AudioClip GetRandomClip()
    //{
    //    //return clips[Random.Range(0, clips.Length)];
    //}

    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.tag == "Grass")
        {
            clip = clipsGrass[Random.Range(0, clipsGrass.Length)];
        }
        if (collision.transform.tag == "Water")
        {
            clip = clipsWater[Random.Range(0, clipsGrass.Length)];
        }
        if (collision.transform.tag == "Wood")
        {
            clip = clipsWood[Random.Range(0, clipsGrass.Length)];
        }
    }
}
