using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItemSoundCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("LifeItemSound");
    }

    public static void LifeItemSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
