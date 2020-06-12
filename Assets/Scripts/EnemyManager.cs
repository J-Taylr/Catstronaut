using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float enemyHealth = 30;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform target;
    [SerializeField] BulletManager bulletManager;
    float bulletDamage;

    private void Start()
    {
       
    }
    void Update()
    {
        float moveSpeed = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
    }

    public void TakeDamage()
    {
        enemyHealth = enemyHealth - bulletDamage;
        print(enemyHealth);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        TakeDamage();
    }
   
    
}
