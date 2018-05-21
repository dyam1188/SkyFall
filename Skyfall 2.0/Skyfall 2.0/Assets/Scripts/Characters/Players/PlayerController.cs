﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the player
public class PlayerController : MonoBehaviour
{
    public Player player;
    public GameObject bullet;

    private Sprite playerSprite;

    private int numLives;
    private int numSpecials;
    private int health;
    private int attack;
    private int defense;

    private float moveSpeed;
    private float shotDensity;

    private bool canShoot;

    [SerializeField]
    private Transform bulletSpawn;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = player.playerSprite;

        numLives = player.numLives;
        numSpecials = player.numSpecials;
        health = player.health;
        attack = player.attack;
        defense = player.defense;

        moveSpeed = player.moveSpeed;
        shotDensity = player.shotDensity;

        canShoot = true;
    }

    void Update()
    {
        GetKeyInput();
    }

    void GetKeyInput()
    {
        Move();
        if (canShoot)
        {
            Shoot();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector3.left * moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector3.right * moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate((Vector3.up * moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate((Vector3.down * moveSpeed) * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
            canShoot = false;
            StartCoroutine(Delay(1 / shotDensity));
        }
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        canShoot = true;
    }

    void ShootBullet()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}