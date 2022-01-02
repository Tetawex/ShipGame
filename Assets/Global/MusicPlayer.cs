using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip MainMenuTheme;
    public AudioClip BattleTheme;

    private AudioClip currentClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        currentClip = null;
    }

    public void PlayClip(AudioClip clip)
    {
        if (currentClip != clip)
        {
            currentClip = clip;
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
