using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    //DAY NE SON
    public float maxHP = 100;
    public float maxSheild = 100;

    private float currentHP;
    private float currentSheild;


    private Vector3 moveInput;

    public SpriteRenderer characterSR;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentHP = maxHP;
        currentSheild = maxSheild;
    }

    // Update is called once per frame
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

}
