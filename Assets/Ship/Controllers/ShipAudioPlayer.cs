using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip death;
    [SerializeField]
    private AudioClip ram;
    [SerializeField]
    private AudioClip shot;

    [SerializeField]
    private AudioSource quietSource;
    [SerializeField]
    private AudioSource loudSource;

    public void PlayDeath()
    {
        loudSource.PlayOneShot(death);
    }
    public void PlayRam()
    {
        loudSource.PlayOneShot(ram);
    }
    public void PlayShot()
    {
        quietSource.PlayOneShot(shot);
    }
}
