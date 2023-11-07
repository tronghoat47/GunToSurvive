using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    Image sheildBar;
    [SerializeField]
    Text healthText;
    [SerializeField]
    Text sheildText;
    [SerializeField]
    Text manaText;

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
        maxHP = Constants.maxBloodPlayer;
        maxSheild = Constants.maxSheild;
        maxMana = Constants.maxManaPlayer;

        currentHP = Constants.maxBloodPlayer;
        currentSheild = Constants.maxSheild;
        currentMana = Constants.maxManaPlayer;

        healthBar.fillAmount = currentHP / maxHP;
        sheildBar.fillAmount = currentSheild / maxSheild;
        manaBar.fillAmount = currentMana / maxMana;
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.position += moveInput * moveSpeed * Time.deltaTime;

        
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.Space) && rollTime <= 0){
            currentMana -= Constants.manaRollOver;
            manaText.text = currentMana.ToString();
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
            animator.SetBool("Roll", true);
        }

        // pause screen
        if (Input.GetKeyDown(KeyCode.Escape)){
            pauseMenu.ShowInforPlayer(currentHP, maxHP, currentMana, maxMana, currentSheild, maxSheild);
            pauseMenu.Pause();
        }

        if(rollTime <= 0 && rollOnce == true){
            animator.SetBool("Roll", false);
            moveSpeed -= rollBoost;
            rollOnce = false;
        }else{
            rollTime -= Time.deltaTime;
        }

        if (moveInput.x != 0){
            if (moveInput.x > 0)
                characterSR.transform.localScale = new Vector3(1f, 1f, 0);
            else
                characterSR.transform.localScale = new Vector3(-1f, 1f, 0);
        }

        if(currentHP > Constants.maxBloodPlayer) {
            currentHP = Constants.maxBloodPlayer;
        }
        if (currentSheild < 0) {
            currentSheild = 0;
        }

        healthBar.fillAmount = currentHP / maxHP;
        healthText.text = "Health: " + currentHP.ToString();

        sheildBar.fillAmount = currentSheild / maxSheild;
        sheildText.text = "Sheild: " + currentSheild.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "moresheild") {
            currentSheild += Constants.moreSheild;
        }

        if (currentSheild > 0) {
            switch(collision.tag) {
                case "bulletEnemy":
                    currentSheild -= Constants.bulletEnemyDame;
                    break;
                case "Enemy":
                    currentSheild -= Constants.enemyDame;
                    break;
                default
                    : break;
            }
        }

        if (currentHP > 0 && currentSheild <=0 ) {
            switch(collision.tag) {
                case "chicken":
                    currentHP += Constants.moreHealthChicken;
                    break;
                case "chickenful":
                    currentHP += Constants.moreHealthChickenFul;
                    break;
                case "bulletEnemy":
                    currentHP -= Constants.bulletEnemyDame;
                    break;
                case "Enemy":
                    currentHP -= Constants.enemyDame;
                    break;
                default:
                    break;
            }
        }

        collision.gameObject.SetActive(false);

    }

}
