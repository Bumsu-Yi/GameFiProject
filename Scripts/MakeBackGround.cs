using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public GameObject bg2;
    //public GameObject bg3;
    public GameObject bg4;
    public GameObject bg5;





    public float timeDiff;
    

    public float x = 19;
    float timer = 0;
    
    
   

    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer > timeDiff)
        {
            
            GameObject newBg1 = Instantiate(bg2);
            newBg1.transform.position = new Vector3(x, Random.Range(-0.2f, 0.5f), 0);
            timer = 0;
            //GameObject newBg2 = Instantiate(bg3);
            //newBg2.transform.position = new Vector3(x, Random.Range(-0.2f, 0.5f), 0);
            //timer = 0;
            GameObject newBg3 = Instantiate(bg4);
            newBg3.transform.position = new Vector3(x, Random.Range(-0.2f, 0.5f), 0);
            timer = 0;
            GameObject newBg4 = Instantiate(bg5);
            newBg4.transform.position = new Vector3(x, Random.Range(-0.2f, 0.5f), 0);
            timer = 0;

            Destroy(newBg1, 60);
            //Destroy(newBg2, 60);
            Destroy(newBg3, 60);
            Destroy(newBg4, 60);


        }
        
        
    }
    
}
