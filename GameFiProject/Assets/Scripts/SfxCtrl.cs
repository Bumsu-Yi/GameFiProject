using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Shot");

        /*
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("moneySound");
        */
    }

   
    
    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public static void ShotSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
    public static void MoneySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
