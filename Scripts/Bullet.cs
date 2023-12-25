using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float dmg = 1;
    public Sprite[] BulletSprites;
    SpriteRenderer spriteRenderer;
    public ObjectManager objectManager;
    Player player;
    float distance;
    Vector3 dir;
    
    Quaternion rotTarget;
    public float bulletSpeed;
    Rigidbody2D rb;
    float maxShotDelay = 1;
    float timer = 0;


    //private void Awake()
    //{
        
    //    timer = 0;
    //    rb = GetComponent<Rigidbody2D>();
    //    transform.position = player.transform.position + Vector3.right * 0.8f + Vector3.down * (0.5f);
    //}

    //private void FixedUpdate()
    //{
    //    //timer += Time.deltaTime;

    //    //guidedMissle(GetNearestObject());
    //}

    //Transform GetNearestObject()
    //{
    //    Transform tMin = null;

    //    GameObject[] enemiesA = objectManager.GetPool("RocketA");
    //    GameObject[] enemiesB = objectManager.GetPool("doge");
    //    GameObject[] enemiesC = objectManager.GetPool("shiba");
    //    GameObject[] enemiesD = objectManager.GetPool("samo");
    //    GameObject[] enemiesE = objectManager.GetPool("jindoge");
    //    GameObject[] enemiesF = objectManager.GetPool("RocketB");
    //    GameObject[] enemiesG = objectManager.GetPool("dogelonmas");
    //    GameObject[] enemiesH = objectManager.GetPool("ItemBox");
    //    GameObject[] enemiesI = objectManager.GetPool("pot");
    //    GameObject[] enemiesJ = objectManager.GetPool("swipe");
    //    GameObject[] enemiesK = objectManager.GetPool("peer");
    //    GameObject[] enemiesL = objectManager.GetPool("luna");
    //    GameObject[] enemiesM = objectManager.GetPool("chilz");
    //    GameObject[] enemiesN = objectManager.GetPool("mana");
    //    GameObject[] enemiesO = objectManager.GetPool("sandbox");
    //    GameObject[] enemiesP = objectManager.GetPool("dai");
    //    GameObject[] enemiesQ = objectManager.GetPool("lite");
    //    GameObject[] enemiesR = objectManager.GetPool("solana");
    //    GameObject[] enemiesS = objectManager.GetPool("avalance");
    //    GameObject[] enemiesT = objectManager.GetPool("ripple");
    //    GameObject[] enemiesU = objectManager.GetPool("ethereum");
    //    GameObject[] enemies = new GameObject[100];
    //    Transform[] enemiePos = new Transform[100];
    //    int indexOfEnemies = 0;

    //    for (int index = 0; index < enemiesA.Length; index++)
    //    {
    //        if (enemiesA[index].activeSelf && enemiesA[index].transform.position.x > -3)
    //        { 
    //            enemies[indexOfEnemies] = enemiesA[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesB.Length; index++)
    //    {
    //        if (enemiesB[index].activeSelf && enemiesB[index].transform.position.x > -3)
    //        {

    //            enemies[indexOfEnemies] = enemiesB[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesC.Length; index++)
    //    {
    //        if (enemiesC[index].activeSelf && enemiesC[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesC[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesD.Length; index++)
    //    {
    //        if (enemiesD[index].activeSelf && enemiesD[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesD[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesE.Length; index++)
    //    {
    //        if (enemiesE[index].activeSelf && enemiesE[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesE[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesF.Length; index++)
    //    {
    //        if (enemiesF[index].activeSelf && enemiesF[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesF[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesG.Length; index++)
    //    {
    //        if (enemiesG[index].activeSelf && enemiesG[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesG[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesH.Length; index++)
    //    {
    //        if (enemiesH[index].activeSelf && enemiesH[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesH[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesI.Length; index++)
    //    {
    //        if (enemiesI[index].activeSelf && enemiesI[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesI[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesJ.Length; index++)
    //    {
    //        if (enemiesJ[index].activeSelf && enemiesJ[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesJ[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesK.Length; index++)
    //    {
    //        if (enemiesK[index].activeSelf && enemiesK[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesK[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesL.Length; index++)
    //    {
    //        if (enemiesL[index].activeSelf && enemiesL[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesL[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesM.Length; index++)
    //    {
    //        if (enemiesM[index].activeSelf && enemiesM[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesM[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesN.Length; index++)
    //    {
    //        if (enemiesN[index].activeSelf && enemiesN[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesN[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesO.Length; index++)
    //    {
    //        if (enemiesO[index].activeSelf && enemiesO[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesO[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesP.Length; index++)
    //    {
    //        if (enemiesP[index].activeSelf && enemiesP[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesP[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesQ.Length; index++)
    //    {
    //        if (enemiesQ[index].activeSelf && enemiesQ[index].transform.position.x > -3)
    //        {
    //            enemies[indexOfEnemies] = enemiesQ[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesR.Length; index++)
    //    {
    //        if (enemiesR[index].activeSelf)
    //        {
    //            enemies[indexOfEnemies] = enemiesR[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesS.Length; index++)
    //    {
    //        if (enemiesS[index].activeSelf)
    //        {
    //            enemies[indexOfEnemies] = enemiesS[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesT.Length; index++)
    //    {
    //        if (enemiesT[index].activeSelf)
    //        {
    //            enemies[indexOfEnemies] = enemiesT[index];
    //            indexOfEnemies++;
    //        }
    //    }
    //    for (int index = 0; index < enemiesU.Length; index++)
    //    {
    //        if (enemiesU[index].activeSelf)
    //        {
    //            enemies[indexOfEnemies] = enemiesU[index];
    //            indexOfEnemies++;
    //        }
    //    }

    //    for (int i = 0; i < indexOfEnemies; i++)
    //    {
    //        enemiePos[i] = enemies[i].transform;
    //    }



    //    float minDist = Mathf.Infinity;
    //    Vector3 currentPos = transform.position;
    //    for (int i = 0; i < indexOfEnemies; i++)
    //    {
    //        float dist = Vector3.Distance(enemiePos[i].position, currentPos);

    //        if (dist < minDist)
    //        {
    //            tMin = enemiePos[i];
    //            minDist = dist;
    //        }
    //    }

    //    return tMin;
        
    //}

    //void guidedMissle(Transform tMin)
    //{
    //    
    //}
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            gameObject.SetActive(false);
        }
    }
}
