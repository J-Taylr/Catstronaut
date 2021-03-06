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
    [SerializeField] GameObject bigBullet;


    public bool playerIsMoving = false;
    private Vector2 moveDirection;

   public bool boughtBigBullet = false;
    

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
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walking", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            print("collided with turret");
            var enemy = collision.gameObject;
            Destroy(enemy);
            GameManager.Instance.SetHealth();
        }

    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Fire");
            
        }
    }

    private void FireBullet()
    {
        if (boughtBigBullet)
        {
            int rdm = UnityEngine.Random.Range(1, 3);
            if (rdm == 1)
            {
                BulletManager newBullet = Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation).GetComponent<BulletManager>();
            }
            if (rdm == 2)
            {
                BulletManager newBullet = Instantiate(bigBullet, bulletspawn.transform.position, bulletspawn.transform.rotation).GetComponent<BulletManager>();
            }
        }
        else
        {
            BulletManager newBullet = Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation).GetComponent<BulletManager>();
        }
    }

    private void PlayerScore()
    {
            
    }

}
