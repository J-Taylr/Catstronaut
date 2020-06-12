﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float enemyHealth = 30;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform target;    
    [SerializeField] GameObject ExplodeFX;
    float bulletDamage;

  
    void Update()
    {
        float moveSpeed = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
    }

    public void TakeDamage(float damage)
    {
        
        enemyHealth = enemyHealth - damage;
        GameManager.Instance.SetScore(20);
        print(enemyHealth);
        if (enemyHealth <= 0)
        {
            GameManager.Instance.SetScore(100);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(ExplodeFX, transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(ExplodeFX.gameObject, 1);
    }



}