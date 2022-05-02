using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject RocketAPrefab;
    public GameObject dogePrefab;
    public GameObject shibaPrefab;
    public GameObject samoPrefab;
    public GameObject jindogePrefab;
    public GameObject RocketBPrefab;
    public GameObject dogelonmasPrefab;
    public GameObject explosionPrefab;
    


    public GameObject fiftyKPrefab;
    public GameObject fivehundredKPrefab;
    public GameObject oneMPrefab;
    public GameObject tenMPrefab;
    public GameObject fiftyMPrefab;

    public GameObject playerBulletPrefab;
    public GameObject lifeItemPrefab;
    public GameObject powerItemPrefab;
    public GameObject boomItemPrefab;
    public GameObject invicibleItemPrefab;
    public GameObject ItemBoxPrefab;
  

    GameObject[] RocketA;
    GameObject[] doge;
    GameObject[] shiba;
    GameObject[] samo;
    GameObject[] jindoge;
    GameObject[] RocketB;
    GameObject[] dogelonmas;

    GameObject[] fiftyK;
    GameObject[] fivehundredK;
    GameObject[] oneM;
    GameObject[] tenM;
    GameObject[] fiftyM;

    GameObject[] lifeItem;
    GameObject[] powerItem;
    GameObject[] boomItem;
    GameObject[] invicibleItem;
    GameObject[] playerBullet;

    GameObject[] explosion;
    GameObject[] ItemBox;

    public GameObject[] targetPool;

    void Awake()
    {
        RocketA = new GameObject[40];
        doge = new GameObject[40];
        shiba = new GameObject[40];
        samo = new GameObject[40];
        jindoge = new GameObject[40];
        RocketB = new GameObject[40];
        dogelonmas = new GameObject[40];
        


        fiftyK = new GameObject[40];
        fivehundredK = new GameObject[40];
        oneM = new GameObject[40];
        tenM = new GameObject[40];
        fiftyM = new GameObject[40];

        playerBullet = new GameObject[30];

        lifeItem = new GameObject[40];
        powerItem = new GameObject[40];
        boomItem = new GameObject[20];
        invicibleItem = new GameObject[20];
        ItemBox = new GameObject[40];
        explosion = new GameObject[100];
        Generate();
    }


    void Generate()
    {
        for (int index = 0; index < RocketA.Length; index++)
        {
            RocketA[index] = Instantiate(RocketAPrefab);
            RocketA[index].SetActive(false);
        }
        for (int index = 0; index < doge.Length; index++)
        {
            doge[index] = Instantiate(dogePrefab);
            doge[index].SetActive(false);
        }
        for (int index = 0; index < shiba.Length; index++)
        {
            shiba[index] = Instantiate(shibaPrefab);
            shiba[index].SetActive(false);
        }
        for (int index = 0; index < samo.Length; index++)
        {
            samo[index] = Instantiate(samoPrefab);
            samo[index].SetActive(false);
        }
        for (int index = 0; index < jindoge.Length; index++)
        {
            jindoge[index] = Instantiate(jindogePrefab);
            jindoge[index].SetActive(false);
        }
        for (int index = 0; index < RocketB.Length; index++)
        {
            RocketB[index] = Instantiate(RocketBPrefab);
            RocketB[index].SetActive(false);
        }
        for (int index = 0; index < dogelonmas.Length; index++)
        {
            dogelonmas[index] = Instantiate(dogelonmasPrefab);
            dogelonmas[index].SetActive(false);
        }
        for (int index = 0; index < fiftyK.Length; index++)
        {
            fiftyK[index] = Instantiate(fiftyKPrefab);
            fiftyK[index].SetActive(false);
        }
        for (int index = 0; index < fivehundredK.Length; index++)
        {
            fivehundredK[index] = Instantiate(fivehundredKPrefab);
            fivehundredK[index].SetActive(false);
        }
        for (int index = 0; index < oneM.Length; index++)
        {
            oneM[index] = Instantiate(oneMPrefab);
            oneM[index].SetActive(false);
        }
        for (int index = 0; index < tenM.Length; index++)
        {
            tenM[index] = Instantiate(tenMPrefab);
            tenM[index].SetActive(false);
        }
        for (int index = 0; index < fiftyM.Length; index++)
        {
            fiftyM[index] = Instantiate(fiftyMPrefab);
            fiftyM[index].SetActive(false);
        }
        for (int index = 0; index < playerBullet.Length; index++)
        {
            playerBullet[index] = Instantiate(playerBulletPrefab);
            playerBullet[index].SetActive(false);
        }
        for (int index = 0; index < lifeItem.Length; index++)
        {
            lifeItem[index] = Instantiate(lifeItemPrefab);
            lifeItem[index].SetActive(false);
        }
        for (int index = 0; index < powerItem.Length; index++)
        {
            powerItem[index] = Instantiate(powerItemPrefab);
            powerItem[index].SetActive(false);
        }
        for (int index = 0; index < boomItem.Length; index++)
        {
            boomItem[index] = Instantiate(boomItemPrefab);
            boomItem[index].SetActive(false);
        }
        for(int index = 0; index < invicibleItem.Length; index++)
        {
            invicibleItem[index] = Instantiate(invicibleItemPrefab);
            invicibleItem[index].SetActive(false);
        }
        for (int index = 0; index < explosion.Length; index++)
        {
            explosion[index] = Instantiate(explosionPrefab);
            explosion[index].SetActive(false);
        }
        for (int index = 0; index < ItemBox.Length; index++)
        {
            ItemBox[index] = Instantiate(ItemBoxPrefab);
            ItemBox[index].SetActive(false);
        }
    }

    
    public GameObject MakeObj(string type)
    {
        switch(type)
        {
            case "RocketA":
                targetPool = RocketA;
                break;
            case "doge":
                targetPool = doge;
                break;
            case "shiba":
                targetPool = shiba;
                break;
            case "samo":
                targetPool = samo;
                break;
            case "jindoge":
                targetPool = jindoge;
                break;
            case "RocketB":
                targetPool = RocketB;
                break;
            case "dogelonmas":
                targetPool = dogelonmas;
                break;  
            case "fiftyK":
                targetPool = fiftyK;
                break;
            case "fivehundredK":
                targetPool = fivehundredK;
                break;
            case "oneM":
                targetPool = oneM;
                break;
            case "tenM":
                targetPool = tenM;
                break;
            case "fiftyM":
                targetPool = fiftyM;
                break;
            case "PlayerBullet":
                targetPool = playerBullet;
                break;
            case "lifeItem":
                targetPool = lifeItem;
                break;
            case "powerItem":
                targetPool = powerItem;
                break;
            case "boomItem":
                targetPool = boomItem;
                break;
            case "invicibleItem":
                targetPool = invicibleItem;
                break;
            case "explosion":
                targetPool = explosion;
                break;
            case "ItemBox":
                targetPool = ItemBox;
                break;
        }


        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        

        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "RocketA":
                targetPool = RocketA;
                break;
            case "doge":
                targetPool = doge;
                break;
            case "shiba":
                targetPool = shiba;
                break;
            case "samo":
                targetPool = samo;
                break;
            case "jindoge":
                targetPool = jindoge;
                break;
            case "RocketB":
                targetPool = RocketB;
                break;
            case "dogelonmas":
                targetPool = dogelonmas;
                break;
            case "fiftyK":
                targetPool = fiftyK;
                break;
            case "fivehundredK":
                targetPool = fivehundredK;
                break;
            case "oneM":
                targetPool = oneM;
                break;
            case "tenM":
                targetPool = tenM;
                break;
            case "fiftyM":
                targetPool = fiftyM;
                break;
            case "PlayerBullet":
                targetPool = playerBullet;
                break;
            case "lifeItem":
                targetPool = lifeItem;
                break;
            case "powerItem":
                targetPool = powerItem;
                break;
            case "boomItem":
                targetPool = boomItem;
                break;
            case "invicibleItem":
                targetPool = invicibleItem;
                break;
            case "explosion":
                targetPool = explosion;
                break;
            case "ItemBox":
                targetPool = ItemBox;
                break;
        }
        return targetPool;
    }

    
}







