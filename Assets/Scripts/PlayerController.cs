using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveSpeed = 2f;
    private Animator animator;

    [SerializeField]
    private float rollBoost = 2f;
    [SerializeField]
    private float RollTime;
    private float rollTime;
    bool rollOnce = false;

    [SerializeField]
    Image healthBar;
    [SerializeField]
    Image manaBar;
    [SerializeField]
    Text healthText;

    public float maxHP;
    public float maxSheild;
    public float maxMana;

    private float currentHP;
    private float currentSheild;
    private float currentMana;

    private Vector3 moveInput;

    public SpriteRenderer characterSR;

    public PauseMenu pauseMenu;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentHP = Constants.maxBloodPlayer;
        currentSheild = Constants.maxSheild;
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
            animator.SetBool("Roll", true);
        }

        // pause screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.Pause();
        }

        if(rollTime <= 0 && rollOnce == true)
        {
            animator.SetBool("Roll", false);
            moveSpeed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
                characterSR.transform.localScale = new Vector3(1f, 1f, 0);
            else
                characterSR.transform.localScale = new Vector3(-1f, 1f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {
            if(currentSheild <=0) {
                if(collision.gameObject.tag == "bulletEnemy") {
                    currentHP -= Constants.bulletEnemyDame;
                }
                if(collision.gameObject.tag == "Enemy") {
                    currentHP -= Constants.enemyDame;
                }
                healthBar.fillAmount = currentHP / maxHP;
            } else {
                if (collision.gameObject.tag == "bulletEnemy") {
                    currentSheild -= Constants.bulletEnemyDame;
                }
                if (collision.gameObject.tag == "Enemy") {
                    currentSheild -= Constants.enemyDame;
                }
                manaBar.fillAmount = currentSheild / maxSheild;
            }
        }

        healthText.text = currentHP.ToString();
    }

}
