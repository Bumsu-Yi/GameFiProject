using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("EnemyHit");
    }

    public static void EnemyHitSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
