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
        Invoke("OnDisable", 0.4f);        
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
            case "A":
                transform.localScale = Vector3.one;
                break;
            case "B":
                transform.localScale = Vector3.one *1.2f;
                break;
            case "RocketA":
                transform.localScale = Vector3.one * 1.6f;
                break;
            case "RocketB":
                transform.localScale = Vector3.one;
                break;
            case "C":
                transform.localScale = Vector3.one * 1.4f;
                break;
            case "D":
                transform.localScale = Vector3.one * 1.8f;
                break;
            case "E":
                transform.localScale = Vector3.one * 2f;
                break;
            
        }
        
        
        Debug.Log("startExplosion3");
    }
}
