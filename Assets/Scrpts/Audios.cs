using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audios : MonoBehaviour
{
    public AudioSource audioSource; // Un solo AudioSource para todo
    public AudioClip clip1; // Primer AudioClip
    public AudioClip clip2; // Segundo AudioClip
    public AudioClip clip3; // Tercer AudioClip
    void Start()
    {
        PlayClip(clip1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }
}
