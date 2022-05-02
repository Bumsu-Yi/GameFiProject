using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomItemSoundCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("ItemBoom");
    }

    public static void ItemBoomSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
