using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] enemyObjs;
    public Transform[] spawnPoints;
    public Transform playersSpawnPoint;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public float stage1;
    public float stage2;
    public float stage3;
    public float stage4;
    public float stage5;

    public GameObject player;
    public Text scoreText;
    public Text coinText;
    public Text bestScoreText;

    public Image[] coinImage;
    public Image[] lifeImage;
    
    public GameObject gameOverSet;
    public float timer;
    public ObjectManager objectManager;
    public Text [] levelText;
    public Image testImage;
    
  

    private void Awake()
    {
        enemyObjs = new string[] { "RocketA", "doge", "shiba", "samo", "jindoge", "RocketB", "dogelonmas", "RocketB","ItemBox" };  
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        
        curSpawnDelay += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer < stage1)
        {
            if (curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                maxSpawnDelay = Random.Range(0.5f, 3f);
                curSpawnDelay = 0;
            }
        }
        else if(timer < stage2)
        {
            if (curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                SpawnEnemy();
                maxSpawnDelay = Random.Range(0.5f, 3f);
                curSpawnDelay = 0;
            }
        }
        else if (timer < stage3)
        {
            if (curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                maxSpawnDelay = Random.Range(0.5f, 3f);
                curSpawnDelay = 0;
            }
        }
        else if (timer < stage4)
        {
            if (curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                maxSpawnDelay = Random.Range(0.5f, 2f);
                curSpawnDelay = 0;
            }
        }
        else if (timer < stage5)
        {
            if (curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();
                SpawnEnemy();

                maxSpawnDelay = Random.Range(0.5f, 2f);
                curSpawnDelay = 0;
            }
        }

        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = "SCORE " + string.Format("{0:n0}", playerLogic.score);
        coinText.text = string.Format("{0:n0}", playerLogic.numOfCoin) + "K";
        bestScoreText.text = "BEST SCORE " + string.Format("{0:n0}", Player.bestScore);
        

    }


    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 9);
        int ranPoint = Random.Range(0, 10);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;


        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        rigid.velocity = new Vector2(enemyLogic.speed * (-1), 0);
    }

    public void UpdateLifeIcon(int life)
    {
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        for(int index = 0; index<life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void CallExplosion(Vector3 pos, string type)
    {
        Debug.Log("explosion");
        GameObject explosion = objectManager.MakeObj("explosion");
        Explosion explosionLogic = explosion.GetComponent<Explosion>();
        Debug.Log("explosion2");
        explosion.transform.position = pos;
        Debug.Log("explosion3");
        explosionLogic.StartExplosion(type);
        Debug.Log("explosion4");
    }




    public void GameOver()
    {
        
        Time.timeScale = 0;
        GameOverCtrl.GameOverSound();
        gameOverSet.SetActive(true);
    }

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
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    
}