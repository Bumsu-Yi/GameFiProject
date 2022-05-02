using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bg;
    public ObjectManager objectManager;

    public float timeDiff;
    

    public float x = 19;
    float timer = 0;
    
    
   

    void Start()
    {
        GameObject newBg = Instantiate(bg);
        newBg.transform.position = new Vector3(19, 0, 0);
        Destroy(newBg, 80);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer > timeDiff)
        {
            GameObject newBg = Instantiate(bg);
            newBg.transform.position = new Vector3(x, Random.Range(-0.2f, 0.5f), 0);
            timer = 0;
        }
        
        
    }
    
}
