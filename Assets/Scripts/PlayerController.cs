using System;
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
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walking", false);
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
