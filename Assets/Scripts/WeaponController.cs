using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    public GameObject muzzle;
    public GameObject fireEffect;

    private float timeBtwFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoateGun();

        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bullet = Instantiate(BulletPrefab, firePos.position, Quaternion.identity);

        Instantiate(muzzle, firePos.position, transform.rotation, transform);
        Instantiate(fireEffect, firePos.position, transform.rotation, transform);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    void RoateGun()
    {
        //Get and change from pixel to world point
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y , lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(10, -10, 0);
        else
            transform.localScale = new Vector3(10, 10, 0);

    }
}
