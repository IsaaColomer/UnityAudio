using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] clips;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Start()
    {

    }
    public void PlayStep()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
