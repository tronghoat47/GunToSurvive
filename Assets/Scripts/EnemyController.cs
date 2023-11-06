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

    [SerializeField]
    Image heathBar;

    private float maxBlood, currentBlood;
    // Start is called before the first frame update
    void Start()
    {
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

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;

        if(currentBlood <= 0) {
            gameObject.SetActive(false);
        }


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
    }
}
