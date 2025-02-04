using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("AudioSources")]
    public AudioSource Music;
    public AudioSource SFX;
    [Header("AudioClips")]
    public AudioClip background;
    public AudioClip coinCollected;
    public AudioClip destroy;
    public AudioClip injured;
    public AudioClip missile;
    public AudioClip fire;
    public AudioClip coincollection;
    public AudioClip GameOver;
    // Start is called before the first frame update
    void Start()
    {
        Music.clip = background;
        Music.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
