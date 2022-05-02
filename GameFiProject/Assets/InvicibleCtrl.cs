using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibleCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("InvicibleSound");
    }

    public static void InvicibleSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
