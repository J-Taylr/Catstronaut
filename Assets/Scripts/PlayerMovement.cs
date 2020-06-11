using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] PlayerMovement player;
    [SerializeField] Animator animator;
    [Header("bullet")]
    [SerializeField] GameObject bulletspawn;
    [SerializeField] GameObject bullet;
    bool playerIsMoving = false;

    public float moveSpeed;
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
        playerIsMoving = true;

    }

    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation);
        }
    }

    private void AnimationController()
    {
        if (playerIsMoving)
        {
            animator.Play("PlayerWalk");
        }
    
    }

}
