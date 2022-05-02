using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float speed;
    public int health;
    public Sprite[] sprites;
    public int enemyScore;

    public GameManager gameManager;
    public ObjectManager objectManager;
    public GameObject player;
    bool is1SpriteChange = false;
    bool is2SpriteChange = false;
    bool is3SpriteChange = false;
    //public GameObject coin;

    public float maxShotDelay;
    public float curShotDelay;
    float timer;
    public GameObject PlayerBullet;

    SpriteRenderer spriteRenderer;

    void Update()
    {
        timer += Time.deltaTime;
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        is1SpriteChange = false;
        is2SpriteChange = false;
    }

    void OnEnable()
    {
        switch (enemyName)
        {
            case "doge":
                health = 8;
                break;
            case "samo":
                health = 25;
                break;
            case "dogelonmas":
                health = 5;
                break;
            case "RocketA":
                health = 1000;
                break;
            case "RocketB":
                health = 1000;
                break;
            case "shiba":
                health = 8;
                break;
            case "jindoge":
                health = 8;
                break;
            case "ItemBox":
                health = 4;
                break;
        }
    }




    public void OnHit(int dmg)
    {
        if (health <= 0)
            return;

        //sprite change
        if (enemyName == "doge")
        {
            if ((health <= 7 && health >= 6) && (!is1SpriteChange))
            {
                spriteRenderer.sprite = sprites[0];
                is1SpriteChange = true;
            }
            else if ((health <= 5 && health >= 3) && !is2SpriteChange)
            {
                spriteRenderer.sprite = sprites[1];
                is2SpriteChange = true;
            }
            else if((health <= 2 && health >= 1) && !is3SpriteChange)
            {
                spriteRenderer.sprite = sprites[2];
                is2SpriteChange = true;
            }
        }
        else if (enemyName == "samo")
        {
            if ((health <= 23 && health >= 17) && !is1SpriteChange)
            {
                spriteRenderer.sprite = sprites[0];
                is1SpriteChange = true;
            }
            else if ((health <= 16 && health >= 5) && !is2SpriteChange)
            {
                spriteRenderer.sprite = sprites[1];
                is2SpriteChange = true;
            }
            else if((health <= 4 && health >0)&& !is3SpriteChange)
            {
                spriteRenderer.sprite = sprites[2];
                is3SpriteChange = true;
            }
        }
        else if (enemyName == "dogelonmas")
        {
            if ((health <= 4 && health >= 3) && !is1SpriteChange)
            {
                spriteRenderer.sprite = sprites[0];
                is1SpriteChange = true;
            }
            else if ((health == 2) && !is2SpriteChange)
            {
                spriteRenderer.sprite = sprites[1];
                is2SpriteChange = true;
            }
            else if ((health == 1) && !is3SpriteChange)
            {
                spriteRenderer.sprite = sprites[2];
                is3SpriteChange = true;
            }
        }
        else if (enemyName == "shiba")
        {
            if ((health <= 7 && health >= 5) && !is1SpriteChange)
            {
                spriteRenderer.sprite = sprites[0];
                is1SpriteChange = true;
            }
            else if ((health == 4 || health == 3) && !is2SpriteChange)
            {
                spriteRenderer.sprite = sprites[1];
                is2SpriteChange = true;
            }
            else if ((health == 2 || health == 1) && !is3SpriteChange)
            {
                spriteRenderer.sprite = sprites[2];
                is3SpriteChange = true;
            }
        }
        else if (enemyName == "jindoge")
        {
            if ((health <= 7 && health >= 6) && !is1SpriteChange)
            {
                spriteRenderer.sprite = sprites[0];
                is1SpriteChange = true;
            }
            else if ((health <= 5 && health >= 3) && !is2SpriteChange)
            {
                spriteRenderer.sprite = sprites[1];
                is2SpriteChange = true;
            }
            else if ((health == 2 || health == 1) && !is3SpriteChange)
            {
                spriteRenderer.sprite = sprites[2];
                is3SpriteChange = true;
            }
        }
        else if(enemyName == "ItemBox")
        {
            spriteRenderer.sprite = sprites[1];
            Invoke("ReturnSprite", 0.1f);
        }
        

        health -= dmg;

        EnemyHitCtrl.EnemyHitSound();
        //spriteRenderer.sprite = sprites[1];



        //Invoke("ReturnSprite", 0.1f);


        if (enemyName != "ItemBox" && health <= 0)
        {
            Player playerlogic = player.GetComponent<Player>();
            playerlogic.score += enemyScore;

           


            //Random Ratio Item Drop
            int ran = Random.Range(0, 500); //no item
            if (ran < 20)
            {
                GameObject oneM = objectManager.MakeObj("oneM");
                oneM.transform.position = transform.position;
            }
            else if (ran < 22)
            {
                GameObject fiftyM = objectManager.MakeObj("fiftyM");
                fiftyM.transform.position = transform.position;
            }
            else if (ran < 30)
            {
                GameObject tenM = objectManager.MakeObj("tenM");
                tenM.transform.position = transform.position;
            }
            else if (ran < 400)
            {
                GameObject fivehundredK = objectManager.MakeObj("fivehundredK");
                fivehundredK.transform.position = transform.position;
            }
            else if (ran < 500)
            {
                GameObject fiftyK = objectManager.MakeObj("fiftyK");
                fiftyK.transform.position = transform.position;
            }
            /*
            else if (ran < 600)   //coin
            {
                GameObject boomItem = objectManager.MakeObj("boomItem");
                boomItem.transform.position = transform.position;
            }
            else if (ran < 920)
            {
                GameObject invicibleItem = objectManager.MakeObj("invicibleItem");
                invicibleItem.transform.position = transform.position;
            }
            else if (ran < 950)//   
            {
                GameObject powerItem = objectManager.MakeObj("powerItem");
                powerItem.transform.position = transform.position;
            }
            else if (ran < 1000)
            {
                GameObject lifeItem = objectManager.MakeObj("lifeItem");
                lifeItem.transform.position = transform.position;
            }
            */
            gameManager.CallExplosion(transform.position, enemyName);
            EnemyDieCtrl.EnemyDie();
            gameObject.SetActive(false);
        }
        else if(enemyName == "ItemBox" && health <= 0)
        {
            
            int itemRan = Random.Range(0, 100);
            if (itemRan < 20)   
            {
                GameObject boomItem = objectManager.MakeObj("boomItem");
                boomItem.transform.position = transform.position;
            }
            else if (itemRan < 30)
            {
                GameObject invicibleItem = objectManager.MakeObj("invicibleItem");
                invicibleItem.transform.position = transform.position;
            }
            else if (itemRan < 40)//   
            {
                GameObject powerItem = objectManager.MakeObj("powerItem");
                powerItem.transform.position = transform.position;
            }
            else if (itemRan < 80)
            {
                GameObject lifeItem = objectManager.MakeObj("lifeItem");
                lifeItem.transform.position = transform.position;
            }
            gameObject.SetActive(false);
        }
    }


    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BorderBullet")
            gameObject.SetActive(false);
        else if (collision.gameObject.tag == "playerBullet")
        {
            Debug.Log("hit by bullet");
            Bullet bulletLogic = PlayerBullet.GetComponent<Bullet>();
            OnHit(bulletLogic.dmg);

            collision.gameObject.SetActive(false);
        }
    }
}


    
