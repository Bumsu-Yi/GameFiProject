using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
//using System.Data;    C#의 데이터 테이블 때문에 사용
//using MySql.Data;     MYSQL함수들을 불러오기 위해서 사용
//using MySql.Data.MySqlClient;    클라이언트 기능을사용하기 위해서 사용
using System;
using UnityEngine.Networking;
using TMPro;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void reloadPage();

    [DllImport("__Internal")]
    private static extern string getUrl();

    [DllImport("__Internal")]
    private static extern string getAccount();


    [System.Serializable]
    public class NICKNAME
    {
        public string nickName;
    }

    public string[] enemyObjs;
    public Transform[] spawnPoints;
    public Transform playersSpawnPoint;
    public float enemySpeed;
    bool isSpawned;

    public float maxSpawnDelay;
    public float maxItemDelay;
    public float curItemDelay;
    public float curSpawnDelay;
    public float stage1;
    public float stage2;
    public float stage3;
    public float stage4;
    public float stage5;
    public float stage6;
    public float stage7;
    public float stage8;
    public float stage9;
    public float stage10;
    public float delaySecond;

    public GameObject player;
    public GameObject[] followers;
    public Text scoreText;
    public Text coinText;
    public Text bestScoreText;
    public Text numOfDiaText;
    public int numOfDia;

    public Image[] coinImage;
    public Image[] lifeImage;

    public GameObject gameOverSet;
    public GameObject overSet1;
    public GameObject overSet2;
    public GameObject exitButton;
    public float timer;
    public float timer2;
    public ObjectManager objectManager;
    public GameObject level;
    public GameObject leve2;
    public GameObject leve3;
    public GameObject leve4;
    public GameObject leve5;
    public GameObject leve6;
    public GameObject leve7;
    public GameObject leve8;
    public GameObject level9;
    public GameObject level10;

    public GameObject warningMsg;
    public GameObject playButton;
    bool pauseActive = false;
    bool isRotate = false;

    public Text playerText;
    public Image testImage;
    public GameObject levelSet;
    public bool level1Flag = false;
    public bool level2Flag = false;
    public bool level3Flag = false;
    public bool level4Flag = false;
    public bool level5Flag = false;
    public bool level6Flag = false;
    public bool level7Flag = false;
    public bool level8Flag = false;
    public bool level9Flag = false;
    public bool level10Flag = false;
    public Text uiCoinText;
    int deviceWidth;
    int deviceHeight;
    int lifeNum;
    int apiDone = 0;
    float scoreToSend;

   
    private void Awake()
    {
        Application.targetFrameRate = 25;

        StartCoroutine("SpawnEnemy");

        enemyObjs = new string[]{"pot","jindoge","peer","samo","swipe","luna","dogelonmas","chilz","mana","sandbox","dai",
            "RocketC","RocketB","lite","shiba","solana","doge","avalance","ripple","ethereum","ItemBox"};
    }


    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("ACCOUNT", getAccount());

        UnityWebRequest www = UnityWebRequest.Post(getUrl() + "/api/moonGameCoinInfo.do", form);
        yield return www.SendWebRequest();

        if(www.downloadHandler.text == "0")
        {
            reloadPage();
        }
        
        
        enemySpeed = 1;

        UnityWebRequest www2 = UnityWebRequest.Post(getUrl() + "/api/moonGame.do", form);

        yield return www2.SendWebRequest();

        var text = www2.downloadHandler.text;

        NICKNAME nickName = JsonUtility.FromJson<NICKNAME>(text);

        playerText.text = nickName.nickName;
        

        
    }

    private void  Update()
    {
        curSpawnDelay += Time.deltaTime;
        curItemDelay += Time.deltaTime;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", Player.score);
        coinText.text = "X : " + playerLogic.numOfCoin.ToString();
    }

    void Item()
    {
        int ranPoint = UnityEngine.Random.Range(0, 9);
        GameObject enemy = objectManager.MakeObj(enemyObjs[20]);
        enemy.transform.position = spawnPoints[ranPoint].position;
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
    }

    void Level1()
    {
        int ranEnemy = UnityEngine.Random.Range(0, 4);
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1) * enemySpeed, 0);
    }

    void Level2()
    {
        int ranEnemy = UnityEngine.Random.Range(5, 7);
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1f) * enemySpeed, 0);
    }

    void Level3()
    {
        int ranEnemy = UnityEngine.Random.Range(7, 11);
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1f) * enemySpeed, 0);
    }

    void Level4()
    {
        int ranEnemy = UnityEngine.Random.Range(11, 16);
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1f) * enemySpeed, 0);
    }

    void Level5()
    {
        int ranEnemy = UnityEngine.Random.Range(16, 20);
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1f) * enemySpeed, 0);
    }

    void RocketA()
    {
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[11]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1f) * enemySpeed, 0);
        
    }

    void RocketB()
    {
        int ranPoint = UnityEngine.Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[12]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1f) * enemySpeed, 0);
    }
   
    public void UpdateLifeIcon(int life)
    {
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        for (int index = 0; index < life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void CallExplosion(Vector3 pos, string type)
    {
        GameObject explosion = objectManager.MakeObj("explosion");
        Explosion explosionLogic = explosion.GetComponent<Explosion>();

        explosion.transform.position = pos;

        explosionLogic.StartExplosion(type);
    }

    public void CallFreeze(Vector3 pos, string type)
    {
        GameObject Freeze = objectManager.MakeObj("freezeEnemy");
        FreezeEnemy freezeEnemyLogic = Freeze.GetComponent<FreezeEnemy>();
        Freeze.transform.position = pos;
        freezeEnemyLogic.StartFreeze(type);
    }

    public IEnumerator SpawnEnemy()
    {
        delaySecond = 1.85f;
        var wfs = new WaitForSeconds(delaySecond);
        
        while (true)
        {
            yield return wfs;
            Spawn();
        }
    }

    public void Spawn()
    {
        //level1
        if (timer < stage1)
        {
            if (timer > 3 && !level1Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //level.SetActive(true);
                //Invoke("TurnOffStage1", 2f);
                //level1Flag = true;
            }
           
            Level1();
            Level1();
            
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = UnityEngine.Random.Range(10f, 12f);
                curItemDelay = 0;
            }
        }
        //level2
        else if (timer < stage2)
        {
            if (timer > stage2 && !level1Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //leve2.SetActive(true);
                //Invoke("TurnOffStage2", 2f);
                //level1Flag = true;
            }

                Level1();
                Level1();
                Level2();
            
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = UnityEngine.Random.Range(10f, 12f);
                curItemDelay = 0;
            }
        }
        //level3
        else if (timer < stage3)
        {
            if (timer > stage2 && !level3Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //leve3.SetActive(true);
                //Invoke("TurnOffStage3", 2f);
                //level3Flag = true;
            }

                Level1();
                Level2();
                Level3();
                

            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = UnityEngine.Random.Range(9f, 11f);
                curItemDelay = 0;
            }
        }
        //level4
        else if (timer < stage4)
        {
            if (timer > stage3 && !level4Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //leve4.SetActive(true);
                //Invoke("TurnOffStage4", 2f);
                //level4Flag = true;
            }

                Level1();
                Level2();
                Level3();
                RocketA();

            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = UnityEngine.Random.Range(8f, 10f);
                curItemDelay = 0;
            }
        }
        //level5
        else if (timer < stage5)
        {
            if (timer > stage4 && !level5Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //leve5.SetActive(true);
                //Invoke("TurnOffStage5", 2f);
                //level5Flag = true;
            }
                Level2();
                Level3();
                Level4();
                RocketA();
           
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = UnityEngine.Random.Range(7f, 8f);
                curItemDelay = 0;
            }
        }
        //level6
        else if (timer < stage6)
        {
            if (timer > stage5 && !level6Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //leve6.SetActive(true);
                //Invoke("TurnOffStage6", 2f);
                //level6Flag = true;
            }
            
                Level3();
                Level4();
                Level5();
                RocketA();
                RocketB();
                
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = UnityEngine.Random.Range(7f, 8f);
                curItemDelay = 0;
            }
        }
        //level7
        else if (timer < stage7)
        {
            if (timer > stage6 && !level7Flag)
            {
                //StageSoundCtrl.StageSound();

                //leve7.SetActive(true);
                //Invoke("TurnOffStage7", 2f);
                //level7Flag = true;
            }
                Level4();
                Level4();
                Level5();
                RocketA();
                RocketB();
                RocketA();
               
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = 6f;
                curItemDelay = 0;
            }
        }
        //level8
        else if (timer < stage8)
        {
            if (timer > stage7 && !level8Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //leve8.SetActive(true);
                //Invoke("TurnOffStage8", 2f);
                //level8Flag = true;
            }
       
            Level4();
            Level5();
            Level5();
            RocketB();
            RocketB();
            RocketA();
            
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = 6f;
                curItemDelay = 0;
            }
        }
        else if (timer < stage9)
        {
            if (timer > stage7 && !level9Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //level9.SetActive(true);
                //Invoke("TurnOffStage9", 2f);
                //level9Flag = true;
            }

                Level5();
                Level5();
                Level5();
                RocketA();
                RocketB();
                RocketA();
                
            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = 6f;
                curItemDelay = 0;
            }
        }
        else if (timer < stage10)
        {
            if (timer > stage7 && !level10Flag)
            {
                //StageSoundCtrl.StageSound();
                
                //level10.SetActive(true);
                //Invoke("TurnOffStage10", 2f);
                //level10Flag = true;
            }

                Level5();
                Level5();
                Level5();
                RocketA();
                RocketB();
                RocketA();
                RocketB();
                RocketB();

            if (curItemDelay > maxItemDelay)
            {
                Item();
                maxItemDelay = 6f;
                curItemDelay = 0;
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("game over1");
        StartCoroutine(GameResult());
        StartCoroutine(GameLife());
    }

    IEnumerator GameResult()
    {
        Debug.Log("game over2");
        gameOverSet.SetActive(true);
        overSet1.SetActive(true);
        Time.timeScale = 0;
        GameOverCtrl.GameOverSound();

        Player playerLogic = player.GetComponent<Player>();
        string score = Convert.ToString(Player.score);
        string numOfCoin = Convert.ToString(playerLogic.numOfCoin);
        uiCoinText.text = numOfCoin;

        exitButton.SetActive(true);

        WWWForm param = new WWWForm();
        param.AddField("A_SEQ", AESCrypto.AESEncrypt128(score));
        param.AddField("B_SEQ", AESCrypto.AESEncrypt128(numOfCoin));
        UnityWebRequest www = UnityWebRequest.Post(getUrl() + "/api/callGameSetting.do", param);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            //exitButton.SetActive(true);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload incomplete!");
        }

        WWWForm param2 = new WWWForm();
        UnityWebRequest www2 = UnityWebRequest.Post(getUrl() + "/api/moonGameCoinInfo.do", param2);
        yield return www2.SendWebRequest();
        numOfDiaText.text = Convert.ToString(www2.downloadHandler.text);

        if ((www.result == UnityWebRequest.Result.Success) && www2.result == UnityWebRequest.Result.Success)
        {

        }
        else
        {
            Debug.Log("it hasnt completed");
        }
    }


    IEnumerator GameLife()
    {
        WWWForm param2 = new WWWForm();
        UnityWebRequest www2 = UnityWebRequest.Post(getUrl() + "/api/moonGameCoinInfo.do", param2);
        yield return www2.SendWebRequest();
        numOfDiaText.text = Convert.ToString(www2.downloadHandler.text);
    }

    //private IEnumerator WaitUntilResolved(UnityWebRequest request, UnityWebRequest request2)
    //{
    //    yield return request;
    //    yield return request2;

    //    if ((request.result == UnityWebRequest.Result.Success) && request2.result == UnityWebRequest.Result.Success)
    //    {
    //        gameOverSet.SetActive(true);
    //    }
    //    else
    //    {

    //    }
    //}

    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe", 1f);
    }

    void RespawnPlayerExe()
    {
        player.transform.position = playersSpawnPoint.position;
        player.SetActive(true);

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    //다시하기 버튼
    public void GameRetry()
    {
        /*
        if(leftDia() <= 0)
        {
            return;
        }
        */
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void pauseBtn()
    {
        if (pauseActive)
        {
            playButton.SetActive(false);
            AudioListener.pause = false;
            Time.timeScale = 1;
            pauseActive = false;
        }
        else
        {
            playButton.SetActive(true); 
            AudioListener.pause = true;     
            Time.timeScale = 0;
            pauseActive = true;   
        }
    }

    public void pauseBtnP()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (pauseActive)
            {
                playButton.SetActive(false);
                Time.timeScale = 1;
                pauseActive = false;
            }
            else
            {
                playButton.SetActive(true);
                Time.timeScale = 0;
                pauseActive = true;
            }
        }
    }
    public void GameExit()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    reloadPage();
#elif (UNITY_WEBGL)
    reloadPage();
#endif
    }
    public void GetPCT()
    {
        overSet1.SetActive(false);
        overSet2.SetActive(true);
        MoneySoundCtrl.MoneySound();
    }
    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }

    public void TurnOffStage1()
    {
        level.SetActive(false);
    }
    public void TurnOffStage2()
    {
        leve2.SetActive(false);
    }
    public void TurnOffStage3()
    {
        leve3.SetActive(false);
    }
    public void TurnOffStage4()
    {
        leve4.SetActive(false);
    }
    public void TurnOffStage5()
    {
        leve5.SetActive(false);
    }
    public void TurnOffStage6()
    {
        leve6.SetActive(false);
    }
    public void TurnOffStage7()
    {
        leve7.SetActive(false);
    }
    public void TurnOffStage8()
    {
        leve8.SetActive(false);
    }
    public void TurnOffStage9()
    {
        level9.SetActive(false);
    }
    public void TurnOffStage10()
    {
        level10.SetActive(false);
    }
}
