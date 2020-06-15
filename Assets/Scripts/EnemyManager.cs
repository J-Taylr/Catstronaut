using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform target;    
    [SerializeField] GameObject ExplodeFX;
    float bulletDamage;

    private void Start()
    {
        
        speed = Random.Range(3,20);
    }

    void Update()
    {
        float moveSpeed = Time.deltaTime * speed;
        if (speed >= 10) { enemyHealth = 10; }
        else { enemyHealth = Random.Range(10, 30); }
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
    }

    public void TakeDamage(float damage)
    {
        
        enemyHealth = enemyHealth - damage;
        GameManager.Instance.SetScore(20);
        if (enemyHealth <= 0)
        {
            GameManager.Instance.SetScore(100);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
       Instantiate(ExplodeFX, transform.position, Quaternion.Euler(90, 0, 0));
        
    }



}
