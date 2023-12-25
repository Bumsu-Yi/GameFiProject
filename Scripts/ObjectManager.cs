using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject RocketCPrefab;
    public GameObject dogePrefab;
    public GameObject shibaPrefab;
    public GameObject samoPrefab;
    public GameObject jindogePrefab;
    public GameObject RocketBPrefab;
    public GameObject dogelonmasPrefab;
    
    public GameObject ethereumPrefab;
    public GameObject ripplePrefab;
    public GameObject solanaPrefab;
    public GameObject avalancePrefab;
    public GameObject litePrefab;
    public GameObject daiPrefab;
    public GameObject sandboxPrefab;
    public GameObject manaPrefab;
    public GameObject chilzPrefab;
    public GameObject swipePrefab;
    public GameObject potPrefab;
    public GameObject peerPrefab;
    public GameObject lunaPrefab;

    public GameObject explosionPrefab;
    public GameObject freezeEnemyPrefab;
    

    public GameObject fiftyKPrefab;
    public GameObject fivehundredKPrefab;
    public GameObject oneMPrefab;
    public GameObject tenMPrefab;
    public GameObject fiftyMPrefab;

    public GameObject playerBulletAPrefab;
    public GameObject playerBulletBPrefab;
    public GameObject playerBulletCPrefab;
    public GameObject playerBulletDPrefab;
    public GameObject playerBulletEPrefab;
    public GameObject raddish1Prefab;
    public GameObject raddish2Prefab;
    public GameObject raddish3Prefab;
    public GameObject raddish4Prefab;
    public GameObject raddish5Prefab;
    public GameObject rice1Prefab;
    public GameObject rice2Prefab;
    public GameObject rice3Prefab;
    public GameObject rice4Prefab;
    public GameObject rice5Prefab;
    public GameObject cucomber1Prefab;
    public GameObject cucomber2Prefab;
    public GameObject cucomber3Prefab;
    public GameObject cucomber4Prefab;
    public GameObject cucomber5Prefab;
    public GameObject onion1Prefab;
    public GameObject onion2Prefab;
    public GameObject onion3Prefab;
    public GameObject onion4Prefab;
    public GameObject onion5Prefab;
    public GameObject brocolli1Prefab;
    public GameObject brocolli2Prefab;
    public GameObject brocolli3Prefab;
    public GameObject brocolli4Prefab;
    public GameObject brocolli5Prefab;

    public GameObject missilePrefab;

    public GameObject smallItemPrefab;
    public GameObject lifeItemPrefab;
    public GameObject powerItemPrefab;
    public GameObject boomItemPrefab;
    public GameObject invicibleItemPrefab;
    public GameObject speedItemPrefab;
    public GameObject freezeItemPrefab;
    public GameObject ItemBoxPrefab;

    //enemies
    const string RocketCStr = "RocketC";
    const string dogeStr = "doge";
    const string shibaStr = "shiba";
    const string samoStr = "samo";
    const string jindogeStr = "jindoge";
    const string RocketBStr = "RocketB";
    const string dogelonmasStr = "dogelonmas";
    const string ethereumStr = "ethereum";
    const string rippleStr = "ripple";
    const string solanaStr = "solana";
    const string avalanaceStr = "avalance";
    const string liteStr = "lite";
    const string daiStr = "dai";
    const string sandboxStr = "sandbox";
    const string manaStr = "mana";
    const string chilzStr = "chilz";
    const string swipeStr = "swipe";
    const string potStr = "pot";
    const string peerStr = "peer";
    const string lunaStr = "luna";

    //item
    const string fiftyKStr = "fiftyK";
    const string fivehundredKStr = "fivehundredK";
    const string oneMStr = "oneM";
    const string tenMStr = "tenM";
    const string fiftyMStr = "fiftyMStr";

    const string lifeItemStr = "lifeItem";
    const string powerItemStr = "powerItem";
    const string boomItemStr = "boomItem";
    const string invicibleStr = "invicibleItem";
    const string smallItemStr = "SmallItem";
    const string speedItemStr = "SpeedItem";
    //const string freezeItemStr = "freezeItemStr";

    //bullets
    const string playerBulletAStr = "PlayerBulletA";
    const string playerBulletBStr = "PlayerBulletB";
    const string playerBulletCStr = "PlayerBulletC";
    const string playerBulletDStr = "PlayerBulletD";
    const string playerBulletEStr = "PlayerBulletE";
    const string raddish1Str = "raddish1";
    const string raddish2Str = "raddish2";
    const string raddish3Str = "raddish3";
    const string raddish4Str = "raddish4";
    const string raddish5Str = "raddish5";
    const string rice1Str = "rice1";
    const string rice2Str = "rice2";
    const string rice3Str = "rice3";
    const string rice4Str = "rice4";
    const string rice5Str = "rice5";
    const string cucomber1Str = "cucomber1";
    const string cucomber2Str = "cucomber2";
    const string cucomber3Str = "cucomber3";
    const string cucomber4Str = "cucomber4";
    const string cucomber5Str = "cucomber5";
    const string onion1Str = "onion1";
    const string onion2Str = "onion2";
    const string onion3Str = "onion3";
    const string onion4Str = "onion4";
    const string onion5Str = "onion5";
    const string brocolli1Str = "brocolli1";
    const string brocolli2Str = "brocolli2";
    const string brocolli3Str = "brocolli3";
    const string brocolli4Str = "brocolli4";
    const string brocolli5Str = "brocolli5";

    const string missileStr = "missile";
    //const string freezeEnemyStr = "freezeEnemy";
    const string explosionStr = "explosion";
    const string itemboxStr = "ItemBox";
    
    GameObject[] RocketC;
    GameObject[] doge;
    GameObject[] shiba;
    GameObject[] samo;
    GameObject[] jindoge;
    GameObject[] RocketB;
    GameObject[] dogelonmas;
    
    GameObject[] ethereum;
    GameObject[] ripple;
    GameObject[] solana;
    GameObject[] avalance;
    GameObject[] lite;
    GameObject[] dai;
    GameObject[] sandbox;
    GameObject[] mana;
    GameObject[] chilz;
    GameObject[] swipe;
    GameObject[] pot;
    GameObject[] peer;
    GameObject[] luna;
    

    GameObject[] fiftyK;
    GameObject[] fivehundredK;
    GameObject[] oneM;
    GameObject[] tenM;
    GameObject[] fiftyM;

    GameObject[] lifeItem;
    GameObject[] powerItem;
    GameObject[] boomItem;
    GameObject[] invicibleItem;
    GameObject[] smallItem;
    GameObject[] speedItem;
    GameObject[] freezeItem;
    GameObject[] playerBulletA;
    GameObject[] playerBulletB;
    GameObject[] playerBulletC;
    GameObject[] playerBulletD;
    GameObject[] playerBulletE;
    GameObject[] raddish1;
    GameObject[] raddish2;
    GameObject[] raddish3;
    GameObject[] raddish4;
    GameObject[] raddish5;
    GameObject[] rice1;
    GameObject[] rice2;
    GameObject[] rice3;
    GameObject[] rice4;
    GameObject[] rice5;
    GameObject[] cucomber1;
    GameObject[] cucomber2;
    GameObject[] cucomber3;
    GameObject[] cucomber4;
    GameObject[] cucomber5;
    GameObject[] onion1;
    GameObject[] onion2;
    GameObject[] onion3;
    GameObject[] onion4;
    GameObject[] onion5;
    GameObject[] brocolli1;
    GameObject[] brocolli2;
    GameObject[] brocolli3;
    GameObject[] brocolli4;
    GameObject[] brocolli5;


    GameObject[] missile;

    GameObject[] freezeEnemy;
    GameObject[] explosion;
    GameObject[] ItemBox;

    public GameObject[] targetPool;

    void Awake()
    {
        RocketC = new GameObject[40];
        doge = new GameObject[40];
        shiba = new GameObject[40];
        samo = new GameObject[40];
        jindoge = new GameObject[40];
        RocketB = new GameObject[40];
        dogelonmas = new GameObject[40];

        
        ethereum = new GameObject[40];
        ripple = new GameObject[40];
        solana = new GameObject[40];
        avalance = new GameObject[40];
        lite = new GameObject[40];
        dai = new GameObject[40];
        sandbox = new GameObject[40];
        mana = new GameObject[40];
        chilz = new GameObject[40];
        swipe = new GameObject[40];
        pot = new GameObject[40];
        peer = new GameObject[40];
        luna = new GameObject[40];
        

        fiftyK = new GameObject[150];
        fivehundredK = new GameObject[50];
        oneM = new GameObject[40];
        tenM = new GameObject[40];
        fiftyM = new GameObject[40];

        playerBulletA = new GameObject[30];
        playerBulletB = new GameObject[30];
        playerBulletC = new GameObject[30];
        playerBulletD = new GameObject[30];
        playerBulletE = new GameObject[30];
        raddish1 = new GameObject[30];
        raddish2 = new GameObject[30];
        raddish3 = new GameObject[30];
        raddish4 = new GameObject[30];
        raddish5 = new GameObject[30];
        rice1 = new GameObject[30];
        rice2 = new GameObject[30];
        rice3 = new GameObject[30];
        rice4 = new GameObject[30];
        rice5 = new GameObject[30];
        cucomber1 = new GameObject[30];
        cucomber2 = new GameObject[30];
        cucomber3 = new GameObject[30];
        cucomber4 = new GameObject[30];
        cucomber5 = new GameObject[30];
        onion1 = new GameObject[30];
        onion2 = new GameObject[30];
        onion3 = new GameObject[30];
        onion4 = new GameObject[30];
        onion5 = new GameObject[30];
        brocolli1 = new GameObject[30];
        brocolli2 = new GameObject[30];
        brocolli3 = new GameObject[30];
        brocolli4 = new GameObject[30];
        brocolli5 = new GameObject[30];

        missile = new GameObject[30];

        lifeItem = new GameObject[40];
        powerItem = new GameObject[40];
        boomItem = new GameObject[20];
        invicibleItem = new GameObject[20];
        smallItem = new GameObject[20];
        speedItem = new GameObject[20];
        freezeItem = new GameObject[20];
        ItemBox = new GameObject[40];
        explosion = new GameObject[100];
        

        Generate();
    }


    void Generate()
    {
        for (int index = 0; index < RocketC.Length; index++)
        {
            RocketC[index] = Instantiate(RocketCPrefab);
            RocketC[index].SetActive(false);
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
        for (int index = 0; index < ethereum.Length; index++)
        {
            ethereum[index] = Instantiate(ethereumPrefab);
            ethereum[index].SetActive(false);
        }
        for (int index = 0; index < ripple.Length; index++)
        {
            ripple[index] = Instantiate(ripplePrefab);
            ripple[index].SetActive(false);
        }
        for (int index = 0; index < solana.Length; index++)
        {
            solana[index] = Instantiate(solanaPrefab);
            solana[index].SetActive(false);
        }
        for (int index = 0; index < avalance.Length; index++)
        {
            avalance[index] = Instantiate(avalancePrefab);
            avalance[index].SetActive(false);
        }
        for (int index = 0; index < lite.Length; index++)
        {
            lite[index] = Instantiate(litePrefab);
            lite[index].SetActive(false);
        }
        for (int index = 0; index < dai.Length; index++)
        {
            dai[index] = Instantiate(daiPrefab);
            dai[index].SetActive(false);
        }
        for (int index = 0; index < sandbox.Length; index++)
        {
            sandbox[index] = Instantiate(sandboxPrefab);
            sandbox[index].SetActive(false);
        }
        for (int index = 0; index < mana.Length; index++)
        {
            mana[index] = Instantiate(manaPrefab);
            mana[index].SetActive(false);
        }
        for (int index = 0; index < chilz.Length; index++)
        {
            chilz[index] = Instantiate(chilzPrefab);
            chilz[index].SetActive(false);
        }
        for (int index = 0; index < swipe.Length; index++)
        {
            swipe[index] = Instantiate(swipePrefab);
            swipe[index].SetActive(false);
        }
        for (int index = 0; index < pot.Length; index++)
        {
            pot[index] = Instantiate(potPrefab);
            pot[index].SetActive(false);
        }
        for (int index = 0; index < peer.Length; index++)
        {
            peer[index] = Instantiate(peerPrefab);
            peer[index].SetActive(false);
        }
        for (int index = 0; index < luna.Length; index++)
        {
            luna[index] = Instantiate(lunaPrefab);
            luna[index].SetActive(false);
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
        for (int index = 0; index < playerBulletA.Length; index++)
        {
            playerBulletA[index] = Instantiate(playerBulletAPrefab);
            playerBulletA[index].SetActive(false);
        }
        for (int index = 0; index < playerBulletB.Length; index++)
        {
            playerBulletB[index] = Instantiate(playerBulletBPrefab);
            playerBulletB[index].SetActive(false);
        }
        for (int index = 0; index < playerBulletC.Length; index++)
        {
            playerBulletC[index] = Instantiate(playerBulletCPrefab);
            playerBulletC[index].SetActive(false);
        }
        for (int index = 0; index < playerBulletD.Length; index++)
        {
            playerBulletD[index] = Instantiate(playerBulletDPrefab);
            playerBulletD[index].SetActive(false);
        }
        for (int index = 0; index < playerBulletE.Length; index++)
        {
            playerBulletE[index] = Instantiate(playerBulletEPrefab);
            playerBulletE[index].SetActive(false);
        }
        for (int index = 0; index < raddish1.Length; index++)
        {
            raddish1[index] = Instantiate(raddish1Prefab);
            raddish1[index].SetActive(false);
        }
        for (int index = 0; index < raddish2.Length; index++)
        {
            raddish2[index] = Instantiate(raddish2Prefab);
            raddish2[index].SetActive(false);
        }
        for (int index = 0; index < raddish3.Length; index++)
        {
            raddish3[index] = Instantiate(raddish3Prefab);
            raddish3[index].SetActive(false);
        }
        for (int index = 0; index < raddish4.Length; index++)
        {
            raddish4[index] = Instantiate(raddish4Prefab);
            raddish4[index].SetActive(false);
        }
        for (int index = 0; index < raddish5.Length; index++)
        {
            raddish5[index] = Instantiate(raddish5Prefab);
            raddish5[index].SetActive(false);
        }
        for (int index = 0; index < rice1.Length; index++)
        {
            rice1[index] = Instantiate(rice1Prefab);
            rice1[index].SetActive(false);
        }
        for (int index = 0; index < rice2.Length; index++)
        {
            rice2[index] = Instantiate(rice2Prefab);
            rice2[index].SetActive(false);
        }
        for (int index = 0; index < rice3.Length; index++)
        {
            rice3[index] = Instantiate(rice3Prefab);
            rice3[index].SetActive(false);
        }
        for (int index = 0; index < rice4.Length; index++)
        {
            rice4[index] = Instantiate(rice4Prefab);
            rice4[index].SetActive(false);
        }
        for (int index = 0; index < rice5.Length; index++)
        {
            rice5[index] = Instantiate(rice5Prefab);
            rice5[index].SetActive(false);
        }
        for (int index = 0; index < cucomber1.Length; index++)
        {
            cucomber1[index] = Instantiate(cucomber1Prefab);
            cucomber1[index].SetActive(false);
        }
        for (int index = 0; index < cucomber2.Length; index++)
        {
            cucomber2[index] = Instantiate(cucomber2Prefab);
            cucomber2[index].SetActive(false);
        }
        for (int index = 0; index < cucomber3.Length; index++)
        {
            cucomber3[index] = Instantiate(cucomber3Prefab);
            cucomber3[index].SetActive(false);
        }
        for (int index = 0; index < cucomber4.Length; index++)
        {
            cucomber4[index] = Instantiate(cucomber4Prefab);
            cucomber4[index].SetActive(false);
        }
        for (int index = 0; index < cucomber5.Length; index++)
        {
            cucomber5[index] = Instantiate(cucomber5Prefab);
            cucomber5[index].SetActive(false);
        }
        for (int index = 0; index < onion1.Length; index++)
        {
            onion1[index] = Instantiate(onion1Prefab);
            onion1[index].SetActive(false);
        }
        for (int index = 0; index < onion2.Length; index++)
        {
            onion2[index] = Instantiate(onion2Prefab);
            onion2[index].SetActive(false);
        }
        for (int index = 0; index < onion3.Length; index++)
        {
            onion3[index] = Instantiate(onion3Prefab);
            onion3[index].SetActive(false);
        }
        for (int index = 0; index < onion4.Length; index++)
        {
            onion4[index] = Instantiate(onion4Prefab);
            onion4[index].SetActive(false);
        }
        for (int index = 0; index < onion5.Length; index++)
        {
            onion5[index] = Instantiate(onion5Prefab);
            onion5[index].SetActive(false);
        }
        for (int index = 0; index < brocolli1.Length; index++)
        {
            brocolli1[index] = Instantiate(brocolli1Prefab);
            brocolli1[index].SetActive(false);
        }
        for (int index = 0; index < brocolli2.Length; index++)
        {
            brocolli2[index] = Instantiate(brocolli2Prefab);
            brocolli2[index].SetActive(false);
        }
        for (int index = 0; index < brocolli3.Length; index++)
        {
            brocolli3[index] = Instantiate(brocolli3Prefab);
            brocolli3[index].SetActive(false);
        }
        for (int index = 0; index < brocolli4.Length; index++)
        {
            brocolli4[index] = Instantiate(brocolli4Prefab);
            brocolli4[index].SetActive(false);
        }
        for (int index = 0; index < brocolli5.Length; index++)
        {
            brocolli5[index] = Instantiate(brocolli5Prefab);
            brocolli5[index].SetActive(false);
        }
        for (int index = 0; index < missile.Length; index++)
        {
            missile[index] = Instantiate(missilePrefab);
            missile[index].SetActive(false);
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
        for (int index = 0; index < smallItem.Length; index++)
        {
            smallItem[index] = Instantiate(smallItemPrefab);
            smallItem[index].SetActive(false);
        }
        for (int index = 0; index < speedItem.Length; index++)
        {
            speedItem[index] = Instantiate(speedItemPrefab);
            speedItem[index].SetActive(false);
        }
        /*
        for (int index = 0; index < freezeItem.Length; index++)
        {
            freezeItem[index] = Instantiate(freezeItemPrefab);
            freezeItem[index].SetActive(false);
        }
        */
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
            case RocketCStr:
                targetPool = RocketC;
                break;
            case dogeStr:
                targetPool = doge;
                break;
            case shibaStr:
                targetPool = shiba;
                break;
            case samoStr:
                targetPool = samo;
                break;
            case jindogeStr:
                targetPool = jindoge;
                break;
            case RocketBStr:
                targetPool = RocketB;
                break;
            case dogelonmasStr:
                targetPool = dogelonmas;
                break;
            case ethereumStr:
                targetPool = ethereum;
                break;
            case rippleStr:
                targetPool = ripple;
                break;
            case solanaStr:
                targetPool = solana;
                break;
            case avalanaceStr:
                targetPool = avalance;
                break;
            case liteStr:
                targetPool = lite;
                break;
            case daiStr:
                targetPool = dai;
                break;
            case sandboxStr:
                targetPool = sandbox;
                break;
            case manaStr:
                targetPool = mana;
                break;
            case chilzStr:
                targetPool = chilz;
                break;
            case swipeStr:
                targetPool = swipe;
                break;
            case potStr:
                targetPool = pot;
                break;
            case peerStr:
                targetPool = peer;
                break;
            case lunaStr:
                targetPool = luna;
                break;
            case fiftyKStr:
                targetPool = fiftyK;
                break;
            case fivehundredKStr:
                targetPool = fivehundredK;
                break;
            case oneMStr:
                targetPool = oneM;
                break;
            case tenMStr:
                targetPool = tenM;
                break;
            case fiftyMStr:
                targetPool = fiftyM;
                break;
            case playerBulletAStr:
                targetPool = playerBulletA;
                break;
            case playerBulletBStr:
                targetPool = playerBulletB;
                break;
            case playerBulletCStr:
                targetPool = playerBulletC;
                break;
            case playerBulletDStr:
                targetPool = playerBulletD;
                break;
            case playerBulletEStr:
                targetPool = playerBulletE;
                break;
            case raddish1Str:
                targetPool = raddish1;
                break;
            case raddish2Str:
                targetPool = raddish2;
                break;
            case raddish3Str:
                targetPool = raddish3;
                break;
            case raddish4Str:
                targetPool = raddish4;
                break;
            case raddish5Str:
                targetPool = raddish5;
                break;
            case rice1Str:
                targetPool = rice1;
                break;
            case rice2Str:
                targetPool = rice2;
                break;
            case rice3Str:
                targetPool = rice3;
                break;
            case rice4Str:
                targetPool = rice4;
                break;
            case rice5Str:
                targetPool = rice5;
                break;
            case cucomber1Str:
                targetPool = cucomber1;
                break;
            case cucomber2Str:
                targetPool = cucomber2;
                break;
            case cucomber3Str:
                targetPool = cucomber3;
                break;
            case cucomber4Str:
                targetPool = cucomber4;
                break;
            case cucomber5Str:
                targetPool = cucomber5;
                break;
            case onion1Str:
                targetPool = onion1;
                break;
            case onion2Str:
                targetPool = onion2;
                break;
            case onion3Str:
                targetPool = onion3;
                break;
            case onion4Str:
                targetPool = onion4;
                break;
            case onion5Str:
                targetPool = onion5;
                break;
            case brocolli1Str:
                targetPool = brocolli1;
                break;
            case brocolli2Str:
                targetPool = brocolli2;
                break;
            case brocolli3Str:
                targetPool = brocolli3;
                break;
            case brocolli4Str:
                targetPool = brocolli4;
                break;
            case brocolli5Str:
                targetPool = brocolli5;
                break;
            case missileStr:
                targetPool = missile;
                break;
            case lifeItemStr:
                targetPool = lifeItem;
                break;
            case powerItemStr:
                targetPool = powerItem;
                break;
            case boomItemStr:
                targetPool = boomItem;
                break;
            case invicibleStr:
                targetPool = invicibleItem;
                break;
            case smallItemStr:
                targetPool = smallItem;
                break;
            case speedItemStr:
                targetPool = speedItem;
                break;
            //case freezeItemStr:
                //targetPool = freezeItem;
                //break;
            case explosionStr:
                targetPool = explosion;
                break;
            case itemboxStr:
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
            case RocketCStr:
                targetPool = RocketC;
                break;
            case dogeStr:
                targetPool = doge;
                break;
            case shibaStr:
                targetPool = shiba;
                break;
            case samoStr:
                targetPool = samo;
                break;
            case jindogeStr:
                targetPool = jindoge;
                break;
            case RocketBStr:
                targetPool = RocketB;
                break;
            case dogelonmasStr:
                targetPool = dogelonmas;
                break;
            case ethereumStr:
                targetPool = ethereum;
                break;
            case rippleStr:
                targetPool = ripple;
                break;
            case solanaStr:
                targetPool = solana;
                break;
            case avalanaceStr:
                targetPool = avalance;
                break;
            case liteStr:
                targetPool = lite;
                break;
            case daiStr:
                targetPool = dai;
                break;
            case sandboxStr:
                targetPool = sandbox;
                break;
            case manaStr:
                targetPool = mana;
                break;
            case chilzStr:
                targetPool = chilz;
                break;
            case swipeStr:
                targetPool = swipe;
                break;
            case potStr:
                targetPool = pot;
                break;
            case peerStr:
                targetPool = peer;
                break;
            case lunaStr:
                targetPool = luna;
                break;
            case fiftyKStr:
                targetPool = fiftyK;
                break;
            case fivehundredKStr:
                targetPool = fivehundredK;
                break;
            case oneMStr:
                targetPool = oneM;
                break;
            case tenMStr:
                targetPool = tenM;
                break;
            case fiftyMStr:
                targetPool = fiftyM;
                break;
            case playerBulletAStr:
                targetPool = playerBulletA;
                break;
            case playerBulletBStr:
                targetPool = playerBulletB;
                break;
            case playerBulletCStr:
                targetPool = playerBulletC;
                break;
            case playerBulletDStr:
                targetPool = playerBulletD;
                break;
            case playerBulletEStr:
                targetPool = playerBulletE;
                break;
            case raddish1Str:
                targetPool = raddish1;
                break;
            case raddish2Str:
                targetPool = raddish2;
                break;
            case raddish3Str:
                targetPool = raddish3;
                break;
            case raddish4Str:
                targetPool = raddish4;
                break;
            case raddish5Str:
                targetPool = raddish5;
                break;
            case rice1Str:
                targetPool = rice1;
                break;
            case rice2Str:
                targetPool = rice2;
                break;
            case rice3Str:
                targetPool = rice3;
                break;
            case rice4Str:
                targetPool = rice4;
                break;
            case rice5Str:
                targetPool = rice5;
                break;
            case cucomber1Str:
                targetPool = cucomber1;
                break;
            case cucomber2Str:
                targetPool = cucomber2;
                break;
            case cucomber3Str:
                targetPool = cucomber3;
                break;
            case cucomber4Str:
                targetPool = cucomber4;
                break;
            case cucomber5Str:
                targetPool = cucomber5;
                break;
            case onion1Str:
                targetPool = onion1;
                break;
            case onion2Str:
                targetPool = onion2;
                break;
            case onion3Str:
                targetPool = onion3;
                break;
            case onion4Str:
                targetPool = onion4;
                break;
            case onion5Str:
                targetPool = onion5;
                break;
            case brocolli1Str:
                targetPool = brocolli1;
                break;
            case brocolli2Str:
                targetPool = brocolli2;
                break;
            case brocolli3Str:
                targetPool = brocolli3;
                break;
            case brocolli4Str:
                targetPool = brocolli4;
                break;
            case brocolli5Str:
                targetPool = brocolli5;
                break;
            case missileStr:
                targetPool = missile;
                break;
            case lifeItemStr:
                targetPool = lifeItem;
                break;
            case powerItemStr:
                targetPool = powerItem;
                break;
            case boomItemStr:
                targetPool = boomItem;
                break;
            case invicibleStr:
                targetPool = invicibleItem;
                break;
            case smallItemStr:
                targetPool = smallItem;
                break;
            case speedItemStr:
                targetPool = speedItem;
                break;
            //case freezeItemStr:
                //targetPool = freezeItem;
                //break;
            case explosionStr:
                targetPool = explosion;
                break;
            case itemboxStr:
                targetPool = ItemBox;
                break;

        }
        return targetPool;
    }

    
}







