using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] clipsGrass;
    public AudioClip[] clipsWater;
    public AudioClip[] clipsWood;
    [SerializeField]
    private AudioClip clipGrass;
    [SerializeField]
    private AudioClip clipWater;
    [SerializeField]
    private AudioClip clipWood;
    public Transform raycastOrigin;
    public float distanceToFloor;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Start()
    {

    }

    //public AudioClip GetRandomClip()
    //{
    //    //return clips[Random.Range(0, clips.Length)];
    //}

    public void DoRaycast()
    {
        RaycastHit hit;

        if(Physics.Raycast(raycastOrigin.position, -raycastOrigin.up, out hit, distanceToFloor))
        {
            Debug.DrawLine(raycastOrigin.position, hit.point, Color.black);

            switch (hit.transform.tag)
            {
                case "Grass":
                    clipGrass = clipsGrass[Random.Range(0, clipsGrass.Length)];
                    audioSource.PlayOneShot(clipGrass);
                    break;
                case "Water":
                    clipWater = clipsWater[Random.Range(0, clipsWater.Length)];
                    audioSource.PlayOneShot(clipWater);
                    break;
                case "Wood":
                    clipWood = clipsWood[Random.Range(0, clipsWood.Length)];
                    audioSource.PlayOneShot(clipWood);
                    break;
                default:
                    break;
            }
        }

    }
}
