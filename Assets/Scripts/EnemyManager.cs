﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform target;    
    [SerializeField] GameObject ExplodeFX;
    [SerializeField] Light2D light2D;
    public float maxLight;
    float bulletDamage;
    [Header("Animators")]
    
    [SerializeField] Animator meteorAnim;
 
    public void MeteorSetup(float setupSpeed)
    {
        transform.up = target.position - transform.position;
        //transform.eulerAngles += Vector3.right * 90;
        speed = setupSpeed;
        MeteorLight();
        if (speed >= 7)
        {
            enemyHealth = 10;
            meteorAnim.SetTrigger("IsFast");
        }
        else { enemyHealth = Random.Range(5, 16); }
        if (enemyHealth >= 11)
        {
            transform.localScale *= 2;
        }
    }


    public void MeteorLight()
    {
        light2D.intensity = maxLight * (speed / 14);

    }


    void Update()
    {
        float moveSpeed = Time.deltaTime * speed;
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
    }

    public void TakeDamage(float damage)
    {
        
        enemyHealth = enemyHealth - damage;
        GameManager.Instance.SetScore(20);
        if (enemyHealth <= 0)
        {
            GameManager.Instance.PlayExplosion();
            GameManager.Instance.SetScore(100);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
       Instantiate(ExplodeFX, transform.position, Quaternion.Euler(0, 0, 0));
        
    }



}
