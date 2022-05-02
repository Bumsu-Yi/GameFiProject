using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("PlayerHitSound");
    }
    public static void PlayerHitSound()
    { 
        audioSource.PlayOneShot(audioClip);
    }
}
