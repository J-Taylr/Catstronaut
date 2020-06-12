﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [Header("Player")]
    [SerializeField] float moveSpeed;
    [SerializeField] PlayerController player;
    [SerializeField] Animator animator;
    [Header("Bullet")]
    [SerializeField] GameObject bulletspawn;
    [SerializeField] GameObject bullet;


    public bool playerIsMoving = false;
    private Vector2 moveDirection;


    void Update()
    {
        MovePlayer();
        PlayerShoot();        
        PlayerScore();
    }

 

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }


    private void MovePlayer()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            playerIsMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            playerIsMoving = false;
        }
    }


    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("Fire");
        }
    }

    private void FireBullet()
    {

        BulletManager newBullet = Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation).GetComponent<BulletManager>();
        
    }

    private void PlayerScore()
    {
            
    }

}