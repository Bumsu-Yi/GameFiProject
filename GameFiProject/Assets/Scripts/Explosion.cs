using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent <Animator>();
    }
    private void OnEnable()
    {
        Invoke("OnDisable", 0.7f);        
    }
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void StartExplosion(string target)
    {
        Debug.Log("startExplosion");
        anim.SetTrigger("OnExplosion");

        Debug.Log("startExplosion2");

        
        switch (target)
        {
            case "doge":
                transform.localScale = Vector3.one * 0.3f;
                break;
            case "dogelonmas":
                transform.localScale = Vector3.one * 0.2f;
                break;
            case "RocketA":
                transform.localScale = Vector3.one * 0.2f;
                break;
            case "RocketB":
                transform.localScale = Vector3.one * 0.4f;
                break;
            case "samo":
                transform.localScale = Vector3.one * 0.4f;
                break;
            case "shiba":
                transform.localScale = Vector3.one * 0.3f;
                break;
            case "jindoge":
                transform.localScale = Vector3.one * 0.35f;
                break;
            
        }
        
        
        Debug.Log("startExplosion3");
    }
}
