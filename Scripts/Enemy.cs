using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Enemy : MonoBehaviour
{
    public GameObject freezeEnemy;
    public string enemyName;
    public float speed;
    public float health;
    public Sprite[] sprites;
    public int enemyScore;

    public GameManager gameManager;
    public ObjectManager objectManager;
    public GameObject player;

    public bool isFreeze;
    public float maxShotDelay;
    public float curShotDelay;
    float timer;
    public GameObject PlayerBullet;
    int luck = 0;
    bool onNft;
    SpriteRenderer spriteRenderer;

    [DllImport("__Internal")]
    private static extern string luckKind();

    [DllImport("__Internal")]
    private static extern string nftYnCheck();

    void Update()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        timer += Time.deltaTime;
        rigid.velocity = new Vector2(speed*(-1), 0);
    }

    void Awake()
    {
        onNft = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.sprite = sprites[0];

        if (nftYnCheck() == "YES")
        {
            luck = int.Parse(luckKind());
        }
        else
        {
            luck = 0;
        }

        if (luck == 0)
        {
            luck = 0;
        }
        else if (10 <= luck && luck < 15)
        {
            luck = 1;
        }
        else if (15 <= luck && luck < 22)
        {
            luck = 2;
        }
        else if (22 <= luck && luck <= 30)
        {
            luck = 3;
        }

    }

    
    void OnEnable()
    {
        if(spriteRenderer.sprite != sprites[0])
        {
            spriteRenderer.sprite = sprites[0];
        }

        isFreeze = false;
        
        switch (enemyName)
        {
            case "A":
                health = 5;
                break;
            case "B":
                health = 10;
                break;
            case "C":
                health = 15;
                break;
            case "RocketC":
                health = 1000;
                break;
            case "RocketB":
                health = 1000;
                break;
            case "D":
                health = 20;
                break;
            case "E":
                health = 30;
                break;
            case "ItemBox":
                health = 3;
                break;
        }
        
    }

    public void OnHit(float dmg)
    {
        if (health <= 0)
            return;

        //sprite change
        switch(enemyName)
        {
            case "A":
                if (health <= 4 && health >= 3)
                {
                    spriteRenderer.sprite = sprites[1];

                }
                else if ((health == 2))
                {
                    spriteRenderer.sprite = sprites[2];

                }
                else if ((health == 1))
                {
                    spriteRenderer.sprite = sprites[3];

                }
                break;
            case "B":
                if (health <= 8 && health >= 6)
                {
                    spriteRenderer.sprite = sprites[1];

                }
                else if (health <= 5 && health >= 3)
                {
                    spriteRenderer.sprite = sprites[2];

                }
                else if (health <= 2 && health > 0)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                break;
            case "C":
                if (health <= 13 && health >= 10)
                {
                    spriteRenderer.sprite = sprites[1];

                }
                else if (health <= 9 && health >= 4)
                {
                    spriteRenderer.sprite = sprites[2];

                }
                else if (health <= 3 && health >= 0)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                break;
            case "D":
                if (health <= 17 && health >= 12)
                {
                    spriteRenderer.sprite = sprites[1];

                }
                else if (health <= 11 && health >= 5)
                {
                    spriteRenderer.sprite = sprites[2];

                }
                else if (health <= 4 && health >= 0)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                break;
            case "E":
                if (health <= 26 && health >= 17)
                {
                    spriteRenderer.sprite = sprites[1];

                }
                else if (health <= 16 && health >= 8)
                {
                    spriteRenderer.sprite = sprites[2];

                }
                else if (health <= 7 && health >= 0)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                break;
            case "ItemBox":
                {
                    spriteRenderer.sprite = sprites[1];
                    Invoke("ReturnSprite", 0.1f);
                }
                break;      
        }

        health -= dmg;
        EnemyHitCtrl.EnemyHitSound();

        if (enemyName != "ItemBox" && health <= 0)
        {
            Player playerlogic = player.GetComponent<Player>();
            Player.score += enemyScore;

            //Random Ratio Item Drop
            int ran = Random.Range(0, 2000); //no item
            if (ran < 1)
            {
                GameObject fiftyM = objectManager.MakeObj("fiftyM");
                fiftyM.transform.position = transform.position;
            }
            else if (ran < 3)
            {
                GameObject oneM = objectManager.MakeObj("tenM");
                oneM.transform.position = transform.position;
            }
            else if (ran < 10)
            {
                GameObject oneM = objectManager.MakeObj("oneM");
                oneM.transform.position = transform.position;
            }
            else if (ran < 200)
            {
                GameObject fivehundredK = objectManager.MakeObj("fivehundredK");
                fivehundredK.transform.position = transform.position;
            }
            else if (ran < 2000)
            {
                GameObject fiftyK = objectManager.MakeObj("fiftyK");
                fiftyK.transform.position = transform.position;
            }
            
            gameManager.CallExplosion(transform.position, enemyName);
            EnemyDieCtrl.EnemyDie();
           
            gameObject.SetActive(false);
        }
        else if(enemyName == "ItemBox" && health <= 0)
        {
            switch (luck)
            {
                case 0: 
                    {
                        int itemRan = Random.Range(0, 100);
                        if (itemRan < 1)
                        {

                        }
                        else if (itemRan < 10)
                        {
                            GameObject invicibleItem = objectManager.MakeObj("invicibleItem");
                            invicibleItem.transform.position = transform.position;
                        }
                        else if (itemRan < 30)
                        {
                            GameObject boomItem = objectManager.MakeObj("boomItem");
                            boomItem.transform.position = transform.position;
                        }
                        else if (itemRan < 55)//   
                        {
                            GameObject powerItem = objectManager.MakeObj("powerItem");
                            powerItem.transform.position = transform.position;
                        }
                        else if (itemRan < 70)
                        {
                            GameObject lifeItem = objectManager.MakeObj("lifeItem");
                            lifeItem.transform.position = transform.position;
                        }
                        else if (itemRan < 85)
                        {
                            GameObject smallItem = objectManager.MakeObj("SmallItem");
                            smallItem.transform.position = transform.position;
                        }
                        else if (itemRan < 100)
                        {
                            GameObject speedItem = objectManager.MakeObj("SpeedItem");
                            speedItem.transform.position = transform.position;
                        }


                        if (isFreeze)
                        {
                            Debug.Log("freezed Enemy");
                            freezeEnemy.SetActive(false);
                        }
                        gameObject.SetActive(false);
                    }
                    break;
                case 1:
                    {
                        int itemRan = Random.Range(0, 100);
                        if (itemRan < 1)
                        {

                        }
                        else if (itemRan < 100)
                        {
                            GameObject invicibleItem = objectManager.MakeObj("invicibleItem");
                            invicibleItem.transform.position = transform.position;
                        }
                        else if (itemRan < 30)
                        {
                            GameObject boomItem = objectManager.MakeObj("boomItem");
                            boomItem.transform.position = transform.position;
                        }
                        else if (itemRan < 55)//   
                        {
                            GameObject powerItem = objectManager.MakeObj("powerItem");
                            powerItem.transform.position = transform.position;
                        }
                        else if (itemRan < 70)
                        {
                            GameObject lifeItem = objectManager.MakeObj("lifeItem");
                            lifeItem.transform.position = transform.position;
                        }
                        else if (itemRan < 85)
                        {
                            GameObject smallItem = objectManager.MakeObj("SmallItem");
                            smallItem.transform.position = transform.position;
                        }
                        else if (itemRan < 100)
                        {
                            GameObject speedItem = objectManager.MakeObj("SpeedItem");
                            speedItem.transform.position = transform.position;
                        }

                        if (isFreeze)
                        {
                            Debug.Log("freezed Enemy");
                            freezeEnemy.SetActive(false);
                        }
                        gameObject.SetActive(false);
                    }
                    break;
                case 2:
                    {
                        int itemRan = Random.Range(0, 100);
                        if (itemRan < 1)
                        {

                        }
                        else if (itemRan < 16)
                        {
                            GameObject invicibleItem = objectManager.MakeObj("invicibleItem");
                            invicibleItem.transform.position = transform.position;
                        }
                        else if (itemRan < 30)
                        {
                            GameObject boomItem = objectManager.MakeObj("boomItem");
                            boomItem.transform.position = transform.position;
                        }
                        else if (itemRan < 55)//   
                        {
                            GameObject powerItem = objectManager.MakeObj("powerItem");
                            powerItem.transform.position = transform.position;
                        }
                        else if (itemRan < 70)
                        {
                            GameObject lifeItem = objectManager.MakeObj("lifeItem");
                            lifeItem.transform.position = transform.position;
                        }
                        else if (itemRan < 85)
                        {
                            GameObject smallItem = objectManager.MakeObj("SmallItem");
                            smallItem.transform.position = transform.position;
                        }
                        else if (itemRan < 100)
                        {
                            GameObject speedItem = objectManager.MakeObj("SpeedItem");
                            speedItem.transform.position = transform.position;
                        }


                        if (isFreeze)
                        {
                            Debug.Log("freezed Enemy");
                            freezeEnemy.SetActive(false);
                        }
                        gameObject.SetActive(false);
                    }
                    break;
                case 3:
                    {
                        int itemRan = Random.Range(0, 100);
                        if (itemRan < 1)
                        {

                        }
                        else if (itemRan < 19)
                        {
                            GameObject invicibleItem = objectManager.MakeObj("invicibleItem");
                            invicibleItem.transform.position = transform.position;
                        }
                        else if (itemRan < 30)
                        {
                            GameObject boomItem = objectManager.MakeObj("boomItem");
                            boomItem.transform.position = transform.position;
                        }
                        else if (itemRan < 55)//   
                        {
                            GameObject powerItem = objectManager.MakeObj("powerItem");
                            powerItem.transform.position = transform.position;
                        }
                        else if (itemRan < 70)
                        {
                            GameObject lifeItem = objectManager.MakeObj("lifeItem");
                            lifeItem.transform.position = transform.position;
                        }
                        else if (itemRan < 85)
                        {
                            GameObject smallItem = objectManager.MakeObj("SmallItem");
                            smallItem.transform.position = transform.position;
                        }
                        else if (itemRan < 100)
                        {
                            GameObject speedItem = objectManager.MakeObj("SpeedItem");
                            speedItem.transform.position = transform.position;
                        }

                        if (isFreeze)
                        {
                            Debug.Log("freezed Enemy");
                            freezeEnemy.SetActive(false);
                        }
                        gameObject.SetActive(false);
                    }
                    break;

            }
        }
       
    }


    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BorderBullet"))
            gameObject.SetActive(false);
        else if (collision.gameObject.CompareTag("playerBullet"))
        {
            if (!onNft)
            {
                Debug.Log("hit by bullet");
                Bullet bulletLogic = PlayerBullet.GetComponent<Bullet>();
                OnHit(bulletLogic.dmg);
                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("hit by bullet");
                Bullet bulletLogic = PlayerBullet.GetComponent<Bullet>();
                OnHit(bulletLogic.dmg * 0.75f);
                collision.gameObject.SetActive(false);
            }
            
        }
        else if (collision.gameObject.CompareTag("missile"))
        {
            gameObject.SetActive(false);
        }


    }
}


    
