using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Player : MonoBehaviour
{
    float size;
    Rigidbody2D rb;
    public float force;
    public float initialForce;
    static public float score;
    static public float bestScore;
    Animator anim1;
    Transform tMin = null;

    Vector3 dir;
    Quaternion rotTarget;

    public GameObject freezeEnemy;

    public bool freezeFlag = false;
    public float bulletSpeed;
    public int life;
    public float maxForce;

    public float maxShotDelay;
    public float curShotDelay;
    public GameManager gameManager;
    public ObjectManager objectManager;
    public bool isHit;
    public decimal numOfCoin;
    public GameObject PlayerBulletA;

    public GameObject boomEffect;
    public GameObject freezeEffect;
    public GameObject sheild;
    public GameObject[] Bullets;
    public Sprite[] RabbitSprites;
    public GameObject[] enemies;
    public GameObject DefenceItem;

    public int power = 1;
    public int type = 0;
    public GameObject invicibleEffect;
    public bool directionFlag;
    public int smallLevel = 1;
    public bool isInvicible;
    public bool isSlow;
    public int notFirst;
    public float moveSpeed;
    public float timer;
    public float timer2;
    public string[] BulletA;
    public string playBulletA;
    public string playBulletB;
    public string playBulletC;
    public string playBulletD;
    public string playBulletE;
    public string raddish1;
    public string raddish2;
    public string raddish3;
    public string raddish4;
    public string raddish5;
    public string rice1;
    public string rice2;
    public string rice3;
    public string rice4;
    public string rice5;
    public string cucomber1;
    public string cucomber2;
    public string cucomber3;
    public string cucomber4;
    public string cucomber5;
    public string onion1;
    public string onion2;
    public string onion3;
    public string onion4;
    public string onion5;
    public string brocolli1;
    public string brocolli2;
    public string brocolli3;
    public string brocolli4;
    public string brocolli5;

    public string missile;

    bool nftOn = false;
    int bulletType = 2;
    int luck = 0;
    bool defenceOn = false;

    string typeAndLuck;

    //[DllImport("__Internal")]
    //private static extern string nftYnCheck();

    //[DllImport("__Internal")]
    //private static extern string luckKind();

    //[DllImport("__Internal")]
    //private static extern string missileKind();

    //[DllImport("__Internal")]
    //private static extern string droneCheck();
    public GameObject playerMissile;
    Bullet bullet;

    SpriteRenderer spriteRenderer;

    public bool isRespawnTime;

    private void Awake()
    {
        size = 0.35f;


        //if (nftYnCheck() == "YES")
        //{
        //    nftOn = true;
        //}
        //else
        //{
        //    nftOn = false;
        //}

        defenceOn = false;

        //if (droneCheck() == "YES")
        //{
        //    defenceOn = true;
        //}
        //else
        //{
        //    defenceOn = false;
        //}


        //if (nftOn == true)
        //{
        //    bulletType = int.Parse(missileKind());
        //}

        notFirst = -1;
        anim1 = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        power = 2;

        smallLevel = 1;
        Bullet bulletLogic = PlayerBulletA.GetComponent<Bullet>();
        bulletLogic.dmg = 2;
        maxShotDelay = 0.23f;

        playBulletA = "PlayerBulletA";
        playBulletB = "PlayerBulletB";
        playBulletC = "PlayerBulletC";
        playBulletD = "PlayerBulletD";
        playBulletE = "PlayerBulletE";
        raddish1 = "raddish1";
        raddish2 = "raddish2";
        raddish3 = "raddish3";
        raddish4 = "raddish4";
        raddish5 = "raddish5";
        rice1 = "rice1";
        rice2 = "rice2";
        rice3 = "rice3";
        rice4 = "rice4";
        rice5 = "rice5";
        cucomber1 = "cucomber1";
        cucomber2 = "cucomber2";
        cucomber3 = "cucomber3";
        cucomber4 = "cucomber4";
        cucomber5 = "cucomber5";
        onion1 = "onion1";
        onion2 = "onion2";
        onion3 = "onion3";
        onion4 = "onion4";
        onion5 = "onion5";
        brocolli1 = "brocolli1";
        brocolli2 = "brocolli2";
        brocolli3 = "brocolli3";
        brocolli4 = "brocolli4";
        brocolli5 = "brocolli5";
        missile = "missile";
        isRespawnTime = false;

        if (defenceOn)
        {
            DefenceItem.SetActive(true);
        }
        else
        {
            DefenceItem.SetActive(false);
        }
    }

    void OnEnable()
    { 
        power = power - 1;
        if (smallLevel > 0)
        {
            smallLevel--;
            SmallLevel();
        }

        if (power <= 1)
        {
            power = 1;
        }

        Bullet bulletLogic = PlayerBulletA.GetComponent<Bullet>();
        bulletLogic.dmg = bulletLogic.dmg - 1;

        if (bulletLogic.dmg <= 2)
        {
            bulletLogic.dmg = 2;
        }

        maxShotDelay = maxShotDelay + 0.01f;
        if (maxShotDelay >= 0.25f)
        {
            maxShotDelay = 0.25f;
        }

        Unbeatable();
        notFirst++;
    }

    void ReturnSpeed()
    {
        GameManager gameManagerLogic = gameManager.GetComponent<GameManager>();
        gameManagerLogic.enemySpeed = 1f;
    }

    void Invicible()
    {
        if (isInvicible == false)
        {
            //anim1.SetTrigger("Invicible");
            BGMCtrl.BGMMute();
            Invoke("BGMPlay", 15f);
            MoonerSongCtrl.PlayMoonerSong();
            sheild.SetActive(true);
            GameManager gameManagerLogic = gameManager.GetComponent<GameManager>();
            gameManagerLogic.enemySpeed = 2f;

            invicibleEffect.SetActive(true);
            InvicibleCtrl.InvicibleSound();
            BiggerSprite();
            Invoke("glitter", 0.1f);
            Invoke("OffSheild", 15.1f);
            Invoke("ReturnSprite", 15.1f);
        }
        else
        {
            InvicibleCtrl.InvicibleSound();

            CancelInvoke("ReturnSprite");
            CancelInvoke("OffSheild");
            CancelInvoke("BGMPlay");
            CancelInvoke("AlmostDone");
            CancelInvoke("BoldColor");
            MoonerSongCtrl.StopMoonerSong();
            MoonerSongCtrl.PlayMoonerSong();
            spriteRenderer.color = new Color(1, 1, 1, 1);
            glitter();
            Invoke("OffSheild", 15.1f);
            Invoke("ReturnSprite", 15.1f);
            Invoke("BGMPlay", 15.1f);
        }
        isInvicible = true;
    }

    void AlmostDone()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.1f);
    }

    void glitter()
    {
        Invoke("AlmostDone", 12.5f);
        Invoke("BoldColor", 12.6f);
        Invoke("AlmostDone", 13.1f);
        Invoke("BoldColor", 13.2f);
        Invoke("AlmostDone", 13.6f);
        Invoke("BoldColor", 13.7f);
        Invoke("AlmostDone", 14.2f);
        Invoke("BoldColor", 14.3f);
        Invoke("AlmostDone", 14.8f);
        Invoke("BoldColor", 14.9f);
    }

    void ReturnSprite()
    {
        anim1.SetTrigger("ReturnSprite");

        SmallLevel();
        //transform.localScale = Vector3.one * 0.1926722f;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        //spriteRenderer.sprite = RabbitSprites[0];
        isInvicible = false;
    }

    void BiggerSprite()
    {
        //transform.localScale =  Vector3.one * 0.4f;
        transform.localScale = Vector3.one * size * 2f;
    }

    void Unbeatable()
    {
        isRespawnTime = true;

        Invoke("BoldColor", 1f);
        Invoke("RespawnDone", 1f);
        if (isRespawnTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);

            if (notFirst > -1)
            {
                boom();
            }
        }
    }

    void RespawnDone()
    {
        isRespawnTime = false;
    }

    //Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score += Time.deltaTime * 50;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (bestScore <= score)
        {
            bestScore = score;
        }
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow)) || Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (timer > maxShotDelay)
        {
            Fire();
            timer = 0;
        }
    }

    public void Jump()
    {
        rb.velocity = Vector3.up * 3;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                {
                    if (isInvicible == true)
                    {
                        Enemy enemyLogic = collision.gameObject.GetComponent<Enemy>();
                        enemyLogic.OnHit(2000);
                        return;
                    }
                    if (isRespawnTime)
                        return;
                    if (isHit)
                        return;

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
                    isHit = true;
                }
                break;

            case "BorderBullet":
                {

                    if (isHit)
                        return;
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
                    isHit = true;
                }
                break;
            case "fiftyK":
                {
                    if (isHit)
                        return;

                    numOfCoin += 1;
                    MoneySoundCtrl.MoneySound();
                    collision.gameObject.SetActive(false);
                }
                break;
            case "fivehundredK":
                {
                    if (isHit)
                        return;

                    numOfCoin += 10;
                    MoneySoundCtrl.MoneySound();
                    collision.gameObject.SetActive(false);
                }
                break;
            case "oneM":
                {
                    if (isHit)
                        return;

                    numOfCoin += 20;
                    MoneySoundCtrl.MoneySound();
                    collision.gameObject.SetActive(false);
                }
                break;
            case "tenM":
                {
                    if (isHit)
                        return;

                    numOfCoin += 200;
                    MoneySoundCtrl.MoneySound();
                    collision.gameObject.SetActive(false);
                }
                break;
            case "fiftyM":
                {
                    if (isHit)
                        return;

                    numOfCoin += 1000;
                    MoneySoundCtrl.MoneySound();
                    collision.gameObject.SetActive(false);
                }
                break;
            case "lifeItem":
                {
                    if (isHit)
                        return;

                    if (life >= 3)
                        return;
                    life++;
                    LifeItemSoundCtrl.LifeItemSound();
                    gameManager.UpdateLifeIcon(life);
                    collision.gameObject.SetActive(false);
                }
                break;
            case "powerItem":
                {
                    if (isHit)
                        return;

                    if (power == 5)
                        return;

                    LifeItemSoundCtrl.LifeItemSound();

                    Bullet bulletLogic = PlayerBulletA.GetComponent<Bullet>();
                    bulletLogic.dmg++;
                    power++;

                    collision.gameObject.SetActive(false);
                }
                break;
            case "invicibleItem":
                {
                    if (isHit)
                        return;

                    Invicible();


                    collision.gameObject.SetActive(false);
                }
                break;
            case "boomItem":
                {
                    if (isHit)
                        return;

                    BoomItemSoundCtrl.ItemBoomSound();
                    boom();

                    collision.gameObject.SetActive(false);
                }
                break;
            case "SmallItem":
                {
                    if (isHit)
                        return;
                    if (smallLevel == 5)
                        return;

                    smallLevel++;
                    InvicibleCtrl.InvicibleSound();
                    SmallLevel();

                    collision.gameObject.SetActive(false);
                }
                break;
            case "SpeedItem":
                {
                    if (isHit)
                        return;

                    if (maxShotDelay <= 0.2f)
                        return;
                    maxShotDelay = maxShotDelay - 0.01f;
                    LifeItemSoundCtrl.LifeItemSound();
                    collision.gameObject.SetActive(false);
                }
                break;
        }
    }

    void SmallLevel()
    {
        
        switch (smallLevel)
        {
            case 0:
                transform.localScale = Vector3.one * size;
                break;
            case 1:
                transform.localScale = Vector3.one * (size-0.01f);
                break;
            case 2:
                transform.localScale = Vector3.one * (size-0.02f);
                break;
            case 3:
                transform.localScale = Vector3.one * (size-0.03f);
                break;
            case 4:
                transform.localScale = Vector3.one * (size-0.04f);
                break;
            case 5:
                transform.localScale = Vector3.one * (size-0.05f);
                break;
        }
    }

    void ReturnSize()
    {
        if (!isInvicible)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            transform.localScale = Vector3.one * 0.5f;
            //transform.localScale = Vector3.one * 0.1926722f;
        }
    }

    void InvicibleFlag()
    {
        isInvicible = false;
    }

    void BoldColor()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Fire()
    {
        if (nftOn == false)
        {
            switch (power)
            {
                case 1:
                    {
                        {
                            GameObject bullet = objectManager.MakeObj(playBulletA);
                            bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.up * (0.5f);
                            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                            rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                            SfxCtrl.ShotSound();
                            curShotDelay = 0;
                        }
                    }
                    break;
                case 2:
                    {
                        GameObject bullet = objectManager.MakeObj(playBulletB);
                        bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.up * (0.5f);
                        //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                        SfxCtrl.ShotSound();
                        curShotDelay = 0;
                    }
                    break;
                case 3:
                    {
                        GameObject bullet = objectManager.MakeObj(playBulletC);
                        bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.up * (0.45f);
                        //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                        SfxCtrl.ShotSound();
                        curShotDelay = 0;
                    }
                    break;
                case 4:
                    {
                        GameObject bullet = objectManager.MakeObj(playBulletD);
                        bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.up * (0.45f);
                        //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                        SfxCtrl.ShotSound();
                        curShotDelay = 0;
                    }
                    break;
                case 5:
                    {
                        GameObject bullet = objectManager.MakeObj(playBulletE);
                        bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.up * (0.45f);
                        //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                        SfxCtrl.ShotSound();
                        curShotDelay = 0;
                    }
                    break;
            }
        }
        else if(nftOn == true)
        {
            switch (bulletType)
            {
                case 0:
                    {
                        switch (power)
                        {
                            case 1:
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletA);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletA);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 2:
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletB);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletB);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 3:
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletC);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletC);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 4:
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletD);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletD);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 5:
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletE);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(playBulletE);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                        }
                    }
                    break;
                case 1:
                    {
                        switch (power)
                        {
                            case 1:
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 2:
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 3:
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 4:
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 5:
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(brocolli5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        switch (power)
                        {
                            case 1:
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 2:
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 3:
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 4:
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 5:
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(raddish5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                        }
                    }
                    break;
                case 3:
                    {
                        switch (power)
                        {
                            case 1:
                                {
                                    GameObject bullet = objectManager.MakeObj(rice1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(rice1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 2:
                                {
                                    GameObject bullet = objectManager.MakeObj(rice2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(rice2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 3:
                                {
                                    GameObject bullet = objectManager.MakeObj(rice3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(rice3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 4:
                                {
                                    GameObject bullet = objectManager.MakeObj(rice4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(rice4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 5:
                                {
                                    GameObject bullet = objectManager.MakeObj(rice5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(rice5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                        }
                    }
                    break;
                case 4:
                    {
                        switch (power)
                        {
                            case 1:
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber1);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 2:
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber2);
                                    bullet.transform.position = transform.position + Vector3.right * 0.8f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 3:
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber3);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 4:
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber4);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                            case 5:
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.3f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                {
                                    GameObject bullet = objectManager.MakeObj(cucomber5);
                                    bullet.transform.position = transform.position + Vector3.right * 0.7f + Vector3.down * (0.7f);
                                    //bullet.transform.position = transform.position + Vector3.right * 0.2f;
                                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                                    rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
                                    SfxCtrl.ShotSound();
                                    curShotDelay = 0;
                                }
                                break;
                        }
                    }
                    break;
            }
        }

            //indexOfEnemies = 0;
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
            invicibleEffect.SetActive(false);
        }
        
        void BGMPlay()
        {
            BGMCtrl.BGMPlay();
        }

        void boom()
        {
            boomEffect.SetActive(true);

            Invoke("OffBoomEffect", 0.7f);

            GameObject[] enemiesA = objectManager.GetPool("RocketC");
            GameObject[] enemiesB = objectManager.GetPool("doge");
            GameObject[] enemiesC = objectManager.GetPool("shiba");
            GameObject[] enemiesD = objectManager.GetPool("samo");
            GameObject[] enemiesE = objectManager.GetPool("jindoge");
            GameObject[] enemiesF = objectManager.GetPool("RocketB");
            GameObject[] enemiesG = objectManager.GetPool("dogelonmas");
            GameObject[] enemiesH = objectManager.GetPool("ItemBox");
            GameObject[] enemiesI = objectManager.GetPool("pot");
            GameObject[] enemiesJ = objectManager.GetPool("swipe");
            GameObject[] enemiesK = objectManager.GetPool("peer");
            GameObject[] enemiesL = objectManager.GetPool("luna");
            GameObject[] enemiesM = objectManager.GetPool("chilz");
            GameObject[] enemiesN = objectManager.GetPool("mana");
            GameObject[] enemiesO = objectManager.GetPool("sandbox");
            GameObject[] enemiesP = objectManager.GetPool("dai");
            GameObject[] enemiesQ = objectManager.GetPool("lite");
            GameObject[] enemiesR = objectManager.GetPool("solana");
            GameObject[] enemiesS = objectManager.GetPool("avalance");
            GameObject[] enemiesT = objectManager.GetPool("ripple");
            GameObject[] enemiesU = objectManager.GetPool("ethereum");


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

                    Enemy enemyLogic = enemiesH[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesI.Length; index++)
            {
                if (enemiesI[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesI[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesJ.Length; index++)
            {
                if (enemiesJ[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesJ[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesK.Length; index++)
            {
                if (enemiesK[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesK[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesL.Length; index++)
            {
                if (enemiesL[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesL[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesM.Length; index++)
            {
                if (enemiesM[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesM[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesN.Length; index++)
            {
                if (enemiesN[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesN[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesO.Length; index++)
            {
                if (enemiesO[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesO[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesP.Length; index++)
            {
                if (enemiesP[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesP[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesQ.Length; index++)
            {
                if (enemiesQ[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesQ[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesR.Length; index++)
            {
                if (enemiesR[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesR[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesS.Length; index++)
            {
                if (enemiesS[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesS[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesT.Length; index++)
            {
                if (enemiesT[index].activeSelf)
                {
                    Enemy enemyLogic = enemiesT[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
            for (int index = 0; index < enemiesU.Length; index++)
            {
                if (enemiesU[index].activeSelf)
                {

                    Enemy enemyLogic = enemiesU[index].GetComponent<Enemy>();
                    enemyLogic.OnHit(1000);
                }
            }
        }
    }

