using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    public float initialForce;
    public float score;
    static public float bestScore;
    Animator anim1;

    public int life;
    public float maxForce;

    public float speed;
    public float maxShotDelay;
    public float curShotDelay;
    public GameManager gameManager;
    public ObjectManager objectManager;
    public bool isHit;
    public float numOfCoin;
    public GameObject PlayerBullet;
    public GameObject boomEffect;
    public GameObject sheild;
    public Sprite[] sprites;
    public GameObject[] enemies;

    public bool isInvicible;

    //Bullet bullet;

    SpriteRenderer spriteRenderer;

    public bool isRespawnTime;

    private void Awake()
    {
        anim1 = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    


    
    void OnEnable()
    {
        Unbeatable();
        
        Invoke("Unbeatable", 1);
    }
    
    
    void Invicible()
    {
        isInvicible = true;


        //anim1.enabled = !anim1.enabled;


        anim1.SetTrigger("Invicible");
        spriteRenderer.sprite = sprites[1];
        sheild.SetActive(true);
        

        InvicibleCtrl.InvicibleSound();
        BiggerSprite();

        Invoke("OffSheild", 10f);
        Invoke("ReturnSprite",10f);
        
    }
    void ReturnSprite()
    {
        anim1.SetTrigger("ReturnSprite");
        spriteRenderer.sprite = sprites[0];
        
        transform.localScale = new Vector3(transform.localScale.x - 0.5f,
                                            transform.localScale.y - 0.5f, 0);
        for (int i = 0; i < 7; i++)
        {
            Enemy enemyLogic = enemies[i].GetComponent<Enemy>();
            enemyLogic.speed /= 50;
        }
        isInvicible = false;
    }

    void BiggerSprite()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.5f,
                                            transform.localScale.y + 0.5f, 0);
    }
    

    void Unbeatable()
    {
        isRespawnTime = !isRespawnTime;

        if (isRespawnTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

   
    

    //Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {


        score += Time.deltaTime * 50;

        if(bestScore <= score)
        {
            bestScore = score;
        }

        Jump();
        Fire();
        Reload();
    }

    void Jump()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up  * 3;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(isInvicible == true)
            {
                Debug.Log("isTrue");
                Enemy enemyLogic = collision.gameObject.GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
                return;
            }

            if (isRespawnTime)
                return;

            if (isHit)
                return;

            isHit = true;
            PlayerHitCtrl.PlayerHitSound();
            life--;
            gameManager.UpdateLifeIcon(life);

            if (life <= 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.RespawnPlayer();
            }

            
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "BorderBullet")
        {   
            if (isRespawnTime || isInvicible)
                return;

            if (isHit)
                return;

            isHit = true;
            life--;
            PlayerHitCtrl.PlayerHitSound();
            gameManager.UpdateLifeIcon(life);

            if (life <= 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.RespawnPlayer();
            }

            
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "fiftyK")
        {
            numOfCoin += 50;
            MoneySoundCtrl.MoneySound();
            collision.gameObject.SetActive(false);

        }
        else if (collision.gameObject.tag == "fivehundredK")
        {
            numOfCoin += 500;
            MoneySoundCtrl.MoneySound();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "oneM")
        {
            numOfCoin += 1000;
            MoneySoundCtrl.MoneySound();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "tenM")
        {
            numOfCoin += 10000;
            MoneySoundCtrl.MoneySound();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "fiftyM")
        {
            numOfCoin += 50000;
            MoneySoundCtrl.MoneySound();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "lifeItem")
        {
            if (life >= 3)
                return;
            life++;
            LifeItemSoundCtrl.LifeItemSound();
            gameManager.UpdateLifeIcon(life);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "powerItem")
        {
            Bullet bulletLogic = PlayerBullet.GetComponent<Bullet>();
            if (bulletLogic.dmg == 3 )
                return;

            LifeItemSoundCtrl.LifeItemSound();
            bulletLogic.dmg++;

            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "invicibleItem")
        {
            if (isInvicible == true)
                return;

            /*for (int i = 0; i < 7; i++)
            {
                Enemy enemyLogic = enemies[i].GetComponent<Enemy>();
                enemyLogic.speed *= 50;
            }
            */
            
            Invicible();
            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.tag == "boomItem")
        {
            boomEffect.SetActive(true);
            BoomItemSoundCtrl.ItemBoomSound();
            Invoke("OffBoomEffect", 0.7f);


            GameObject[] enemiesA = objectManager.GetPool("RocketA");
            GameObject[] enemiesB = objectManager.GetPool("doge");
            GameObject[] enemiesC = objectManager.GetPool("shiba");
            GameObject[] enemiesD = objectManager.GetPool("samo");
            GameObject[] enemiesE = objectManager.GetPool("jindoge");
            GameObject[] enemiesF = objectManager.GetPool("RocketB");
            GameObject[] enemiesG = objectManager.GetPool("dogelonmas");
            GameObject[] enemiesH = objectManager.GetPool("ItemBox");


            for (int index = 0; index < enemiesA.Length; index++)
            {
                if (enemiesA[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesA[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesB.Length; index++)
            {
                if (enemiesB[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesB[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesC.Length; index++)
            {
                if (enemiesC[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesC[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesD.Length; index++)
            {
                if (enemiesD[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesD[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesE.Length; index++)
            {
                if (enemiesE[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesE[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesF.Length; index++)
            {
                if (enemiesF[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesF[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesG.Length; index++)
            {
                if (enemiesG[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesG[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesH.Length; index++)
            {
                if (enemiesH[index].activeSelf)
                {
                    Debug.Log("ItemBox");
                    Enemy enemyLogic = enemiesH[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }


            collision.gameObject.SetActive(false);
        }
        


    }
            


    void Fire()
    {
        //if (!Input.GetMouseButton(0))
            //return;

        if (curShotDelay < maxShotDelay)
            return;

            GameObject bullet = objectManager.MakeObj("PlayerBullet");
        bullet.transform.position = transform.position + Vector3.right * 0.5f + Vector3.down * (0.45f);

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
            SfxCtrl.ShotSound();
            curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void OffBoomEffect()
    {
            boomEffect.SetActive(false);
    }
    void OffSheild()
    {
        sheild.SetActive(false);
    }


}

