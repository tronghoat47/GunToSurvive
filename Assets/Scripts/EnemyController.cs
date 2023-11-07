using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    private Rigidbody2D rb;

    public bool isShootAble = false;
    public GameObject bulletEnemyPrefab;
    public float bulletSpeed;   
    public float timeBtwFire;
    private float fireCooldown;

    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Image heathBar;
    [SerializeField]
    Text txtScore;

    private float maxBlood, currentBlood;
    private float score = 1;

    // Start is called before the first frame update
    void Start()
    {
        //txtScore = canvas.transform.Find("TextMyScore").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
        switch (gameObject.name) {
            case "Enemy_01(Clone)":
                maxBlood = Constants.enemy1Blood;
                break;
            case "Enemy_02(Clone)":
                maxBlood = Constants.enemy2Blood;
                break;
            case "Enemy_03(Clone)":
                maxBlood = Constants.enemy3Blood;
                score = 3;
                break;
            case "Enemy_04(Clone)":
                maxBlood = Constants.enemy4Blood;
                break;
            default:
                maxBlood = 10;
                break;
        }
        currentBlood = maxBlood;
        heathBar.fillAmount = currentBlood / maxBlood;
    }

    // Update is called once per frame

    private bool isRendered;

    void OnBecameVisible()
    {
        isRendered = true;
    }

    void OnBecameInvisible()
    {
        isRendered = false;
    }

    private void OnEnable() {
        currentBlood = maxBlood;
        heathBar.fillAmount = currentBlood / maxBlood;
    }
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if(isShootAble && isRendered)
        {
            //Enemy fire
            fireCooldown -= Time.deltaTime;
            if (fireCooldown < 0)
            {
                fireCooldown = timeBtwFire;
                EnemyFireBullet();
            }
        }
        
        Vector2 direction = (target.position - transform.position).normalized;
        if(isShootAble)
        {
            float distance = 5f; // adjust the desired distance here

            // Calculate the distance between the player and the enemy
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);

            // Only move towards the target position if the distance is greater than the desired distance
            if (distanceToPlayer > distance)
            {
                // Calculate the direction towards the player
                Vector2 towardsPlayer = (target.position - transform.position).normalized;

                // Calculate the position that is at the specified distance from the player
                Vector2 targetPosition = (Vector2)target.position - (towardsPlayer * distance);

                // Move towards the target position at a certain speed
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = direction * speed;
        }

        if(currentBlood <= 0) {
            LevelManager.manager.AddScore(score);
            gameObject.SetActive(false);

            //increase score
            //switch (gameObject.name) {
            //    case "Enemy_01(Clone)":
            //        score += Constants.scoreEnemy1;
            //        break;
            //    case "Enemy_02(Clone)":
            //        score += Constants.scoreEnemy2;
            //        break;
            //    case "Enemy_03(Clone)":
            //        score += Constants.scoreEnemy3;
            //        score = 3;
            //        break;
            //    case "Enemy_04(Clone)":
            //        score += Constants.scoreEnemy4;
            //        break;
            //    default:
            //        maxBlood = 10;
            //        break;
            //}
            //txtScore.text = "Score: " + score;
        }
    }

    private void EnemyFireBullet()
    {
        var bulletPre = Instantiate(bulletEnemyPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rbBullet = bulletPre.GetComponent<Rigidbody2D>();
        Vector3 direction = target.position - transform.position;
        rbBullet.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    private void RotateTowardsTarget()
    {
        if (target.transform.position.x - gameObject.transform.position.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            currentBlood -= Constants.bulletPlayerGun;
            heathBar.fillAmount = currentBlood / maxBlood;
        }
        if (collision.gameObject.tag == "Skill") {
            currentBlood = 0;
            heathBar.fillAmount = currentBlood / maxBlood;
        }
    }
}
