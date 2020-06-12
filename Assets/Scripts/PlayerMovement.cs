using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Player")]
    [SerializeField] float moveSpeed;
    [SerializeField] PlayerMovement player;
    [SerializeField] Animator animator;
    [Header("bullet")]
    [SerializeField] GameObject bulletspawn;
    [SerializeField] GameObject bullet;

    bool playerIsMoving = false;
    private Vector2 moveDirection;

    void Update()
    {
        MovePlayer();
        PlayerShoot();
        AnimationController();
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
       Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation);        
    }

    private void AnimationController()
    {
        if (playerIsMoving)
        {
            animator.Play("PlayerWalk");
        }
        if (!playerIsMoving)
        {
            animator.Play("Idle");
        }
    
    }

}
