using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Boom");
    }

    public static void EnemyDie()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
